using System;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using Telerik.Maui.Controls;
using Telerik.XamarinForms.Input;

namespace SDKBrowserMaui.Examples.TemplatedPickerControl.GettingStartedCategory.GettingStartedExample
{
    public class TemplatedPickerGettingStartedCSharp : RadContentView
    {
        public TemplatedPickerGettingStartedCSharp()
        {
            // >> templatedpicker-getting-started-csharp
            var viewModel = new ColorViewModel();
            var templatedPicker = new RadTemplatedPicker
            {
                Placeholder = "Select a Color"
            };
            var displayTemplate = new ControlTemplate(() =>
            {
                var displayLayout = new Grid();
                var displayLabel = new Label
                {
                    Margin = new Thickness(10, 0),
                    TextColor = Colors.Black,
                    VerticalOptions = LayoutOptions.Center
                };
                var textBinding = new Binding
                {
                    Path = "DisplayString",
                    Source = RelativeBindingSource.TemplatedParent
                };
                var colorBinding = new Binding
                {
                    Path = "DisplayString",
                    Source = RelativeBindingSource.TemplatedParent
                };
                var commandBinding = new Binding
                {
                    Path = "ToggleCommand",
                    Source = RelativeBindingSource.TemplatedParent
                };
                var tapRecognizer = new TapGestureRecognizer();

                tapRecognizer.SetBinding(TapGestureRecognizer.CommandProperty, commandBinding);
                displayLabel.SetBinding(Label.TextProperty, textBinding);
                displayLayout.SetBinding(VisualElement.BackgroundColorProperty, colorBinding);
                displayLayout.Children.Add(displayLabel);
                displayLayout.GestureRecognizers.Add(tapRecognizer);

                return displayLayout;
            });
            var selectorTemplate = new ControlTemplate(() =>
            {
                var collectionView = new CollectionView
                {
                    HeightRequest = 240,
                    SelectionMode = SelectionMode.Single,
                };
                var itemsSourceBinding = new Binding
                {
                    Path = "Colors"
                };
                var selectedItemBinding = new Binding
                {
                    Path = "SelectedValue",
                    Source = RelativeBindingSource.TemplatedParent,
                    Mode = BindingMode.TwoWay
                };
                var itemTemplate = new DataTemplate(() =>
                {
                    var itemLayout = new Grid
                    {
                        HeightRequest = 60
                    };
                    var itemBorder = new RadBorder
                    {
                        WidthRequest = 40,
                        HeightRequest = 40,
                        CornerRadius = 20,
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.Center,
                        BorderColor = Colors.LightGray,
                        BorderThickness = 2
                    };
                    var itemBinding = new Binding(".");
                    var visualStates = new VisualStateGroupList
                    {
                        new VisualStateGroup
                        {
                            Name = "CommonStates",
                            States =
                            {
                                new VisualState
                                {
                                    Name = "Normal",
                                    Setters =
                                    {
                                        new Setter
                                        {
                                            Property = VisualElement.BackgroundColorProperty,
                                            Value = Colors.White
                                        }
                                    }
                                },
                                new VisualState
                                {
                                    Name = "Selected",
                                    Setters =
                                    {
                                        new Setter
                                        {
                                            Property = VisualElement.BackgroundColorProperty,
                                            Value = Colors.WhiteSmoke
                                        }
                                    }
                                }
                            }
                        }
                    };

                    itemBorder.SetBinding(VisualElement.BackgroundColorProperty, itemBinding);
                    itemLayout.Children.Add(itemBorder);
                    VisualStateManager.SetVisualStateGroups(itemLayout, visualStates);

                    return itemLayout;
                });
                var itemsLayout = new GridItemsLayout(ItemsLayoutOrientation.Vertical)
                {
                    Span = 5
                };

                collectionView.ItemTemplate = itemTemplate;
                collectionView.ItemsLayout = itemsLayout;
                collectionView.SetBinding(ItemsView.ItemsSourceProperty, itemsSourceBinding);
                collectionView.SetBinding(SelectableItemsView.SelectedItemProperty, selectedItemBinding);

                return collectionView;
            });
            templatedPicker.BindingContext = viewModel;
            templatedPicker.DisplayTemplate = displayTemplate;
            templatedPicker.SelectorTemplate = selectorTemplate;
            // << templatedpicker-getting-started-csharp
            var stackLayout = new VerticalStackLayout();
            stackLayout.Children.Add(templatedPicker);
            stackLayout.Padding = new Thickness(10);
            this.Content = stackLayout;
        }
    }
}
