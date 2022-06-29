(function ($) {
    $.fn.isImage = function () {

        var file = $(this).find('input[type=file]')[0].files[0]
        var fileExt = file.name.split('.').pop();

        var fileLimit = 51202;//kilobyte
        var fileSize = file.size;
        var fileSizeInKB = (fileSize / 1024);

        if (fileSizeInKB < fileLimit) {
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
        } else {
            toastr.error("Fayl 50 mb-dan böyük olmamaıldır !")
            return
        }



    }
})(jQuery);

