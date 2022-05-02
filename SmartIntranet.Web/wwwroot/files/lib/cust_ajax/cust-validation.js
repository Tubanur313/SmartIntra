(function ($) {
    $.fn.isImage = function () {

        var file = $(this).find('input[type=file]')[0].files[0]
        var fileExt = file.name.split('.').pop();

        if (
            fileExt != "jpeg" &&
            fileExt != "jpg" &&
            fileExt != "png" &&
            fileExt != "gif" &&
            fileExt != "pjpeg" &&
            fileExt != "pngsvg" &&
            fileExt != "tiff" &&
            fileExt != "svg" &&
            fileExt != "webp"
        ) {
            return false;
        }
        else {
            return true;

        }

    }
})(jQuery);

