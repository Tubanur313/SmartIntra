"use strict"

$(document).ready(function () {
    const realFileBtn = document.getElementById("files");
    const customBtn = document.getElementById("custom-button");

    customBtn.addEventListener("click", function () {
        realFileBtn.click();
    });

    var fileArr = [];
    $("#files").change(function () {
        
        // check if fileArr length is greater than 0
        if (fileArr.length > 0) fileArr = [];

        $('#image_preview').html("");
        var total_file = document.getElementById("files").files;
        if (!total_file.length) return;
        for (var i = 0; i < total_file.length; i++) {
            if (total_file[i].size > 1048576) {
                return false;
            } else {
                var fileExt = total_file[i].name.split('.').pop();
                fileArr.push(total_file[i]);
                if (
                    fileExt == "jpeg" ||
                    fileExt == "jpg" ||
                    fileExt == "png" ||
                    fileExt == "gif" ||
                    fileExt == "pjpeg" ||
                    fileExt == "pngsvg" ||
                    fileExt == "tiff" ||
                    fileExt == "svg" ||
                    fileExt == "webp"
                ) {
                    $('#image_preview').append("<div class='img-div col-sm-3' id='img-div" + i + "'><label>'" + (total_file[i].name.length > 10 ? total_file[i].name.substring(0, 10) : total_file[i].name.substring(0, 8)) + "...'</label><img src='"
                        + URL.createObjectURL(event.target.files[i])
                        + "' class='img-responsive image img-thumbnail' title='"
                        + total_file[i].name + "'><div class='middle'><button id='action-icon' value='img-div" +
                        i + "' class='btn btn-danger' role='" + total_file[i].name
                        + "'><i class='fa fa-trash'></i></button></div></div>");
                } else {

                    $('#image_preview').append("<div class='img-div col-sm-3' id='img-div" + i + "'><label>'" + (total_file[i].name.length > 10 ? total_file[i].name.substring(0, 10) : total_file[i].name.substring(0, 8)) + "...'</label><img src='"
                        + 'uploads/file.png'
                        + "' class='img-responsive image img-thumbnail' title='"
                        + total_file[i].name + "'><div class='middle'><button id='action-icon' value='img-div" +
                        i + "' class='btn btn-danger' role='" + total_file[i].name
                        + "'><i class='fa fa-trash'></i></button></div></div>");
                }

            }
        }
    });

    $('body').on('click', '#action-icon', function (evt) {
        var divName = this.value;
        var fileName = $(this).attr('role');
        $(`#${divName}`).remove();

        for (var i = 0; i < fileArr.length; i++) {
            if (fileArr[i].name === fileName) {
                fileArr.splice(i, 1);
            }
        }
        $('#files').files = FileListItem(fileArr);
        evt.preventDefault();
    });

    function FileListItem(file) {
        file = [].slice.call(Array.isArray(file) ? file : arguments)
        for (var c, b = c = file.length, d = !0; b-- && d;) d = file[b] instanceof File
        if (!d) throw new TypeError("expected argument to FileList is File or array of File objects")
        for (b = (new ClipboardEvent("")).clipboardData || new DataTransfer; c--;) b.items.add(file[c])
        return b.files
    }
});