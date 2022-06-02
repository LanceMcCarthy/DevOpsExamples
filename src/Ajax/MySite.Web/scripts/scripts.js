;(function () {

    var example = window.example = window.example || {};
    var lightBox;

    example.imageClicked = function (id) {
        lightBox.set_currentItemIndex(parseInt(id, 10) - 1);
        lightBox.show();
    }

    example.radLightBoxLoad = function (sender, eventArgs) {
        lightBox = sender;
    }
})();