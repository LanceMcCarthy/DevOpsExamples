using System.ComponentModel.DataAnnotations;
using Telerik.Maui.Controls;

namespace MauiDemo.Models;

public class DataTypeEditorsModel : NotifyPropertyChangedBase
{
    private string name;
    private DateOnly? startDate;
    private TimeOnly? startTime;
    private DateTime? endDateTime;
    private double? people = 1;
    private bool visited;
    private string phoneNumber;
    private string email;
    private string password;
    private string? url;
    private decimal? cost;
    private string? notes;
    private TimeSpan? duration;
    private EnumValue accommodation = EnumValue.Apartment;
    public enum EnumValue
    {
        SingleRoom,
        Apartment,
        House
    }

    [Required]
    [Display(Name = "First Name")]
    [DataType(DataType.Text)]
    public string FirstName
    {
        get => name;
        set => UpdateValue(ref name, value);
    }

    [Required]
    [Display(Name = "Email address")]
    [DataType(DataType.EmailAddress)]
    [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Please enter valid email address.")]
    public string Email
    {
        get => email;
        set => UpdateValue(ref email, value);
    }

    [Required]
    [Display(Name = "Phone number")]
    [DataType(DataType.PhoneNumber)]
    [RegularExpression(@"^(?!0+$)(\+\d{1,3}[- ]?)?(?!0+$)\d{10,15}$", ErrorMessage = "Please enter valid phone number.")]
    public string PhoneNumber
    {
        get => phoneNumber;
        set => UpdateValue(ref phoneNumber, value);
    }

    [Required]
    [Display(Name = "Enter password")]
    [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}", ErrorMessage = "Password must contain: -at least one upper case, " +
                                                                                                       "at least one lower case, at least one digit, at least one special character and to be at least 8 symbols")]
    [DataType(DataType.Password)]
    public string Password
    {
        get => password;
        set => UpdateValue(ref password, value);
    }

    [Required]
    [Display(Name = "Star date")]
    [DataType(DataType.Date)]
    public DateOnly? StartDate
    {
        get => startDate;
        set => UpdateValue(ref startDate, value);
    }

    [Required]
    [Display(Name = "Start time")]
    [DataType(DataType.Time)]
    public TimeOnly? StartTime
    {
        get => startTime;
        set => UpdateValue(ref startTime, value);
    }

    [Required]
    [Display(Name = "End date and time")]
    [DataType(DataType.DateTime)]
    public DateTime? EndDateTime
    {
        get => endDateTime;
        set => UpdateValue(ref endDateTime, value);
    }

    [Display(Name = "Number of People")]
    public double? People
    {
        get => people;
        set => UpdateValue(ref people, value);
    }

    [Display(Name = "Select accomodation")]
    public EnumValue Accommodation
    {
        get
        {
            return accommodation;
        }
        set
        {
            if (accommodation != value)
            {
                accommodation = value;
                OnPropertyChanged();
            }
        }
    }

    [Display(Name = "Visited before")]
    public bool Visited
    {
        get => visited;
        set => UpdateValue(ref visited, value);
    }

    [Display(Name = "Duration")]
    public TimeSpan? Duration
    {
        get => duration;
        set => UpdateValue(ref duration, value);
    }

    [Display(Name = "Web address")]
    [DataType(DataType.Url)]
    [RegularExpression(@"^(http:\/\/www\.|https:\/\/www\.|http:\/\/|https:\/\/)?[a-z0-9]+([\-\.]{1}[a-z0-9]+)*\.[a-z]{2,5}(:[0-9]{1,5})?(\/.*)?$", ErrorMessage = "Please enter valid url.")]
    public string? URL
    {
        get => url;
        set => UpdateValue(ref url, value);
    }

    [Display(Name = "Total cost")]
    [DataType(DataType.Currency)]
    [DisplayFormat(DataFormatString = "C")]
    public decimal? Cost
    {
        get => cost;
        set => UpdateValue(ref cost, value);
    }

    [Display(Name = "Notes")]
    [DataType(DataType.MultilineText)]
    public string? Notes
    {
        get => notes;
        set => UpdateValue(ref notes, value);
    }
}