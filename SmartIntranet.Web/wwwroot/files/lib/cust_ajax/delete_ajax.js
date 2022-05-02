$.fn.getFormData = function (addProperties) {
    let tempt = this;
    var data = {};
    $(tempt).find('a[name]').each(function (index, item) {
        data[item.name] = item.value;
    })
    data = $.extend(data, addProperties);
    return data;
}


//delete listed items from table
function removeItem(_id, _name, _path) {

    swal({
        title: `Diqqət`,
        text: `Əminsiniz ki, '${_name}' siyahıdan silinsin?`,
        icon: "warning",
        buttons: ["Xeyr", "Bəli"],
        dangerMode: true,
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: 'get',
                url: _path,
                datatype: 'json',
                data: { id: _id },
                success: function (response) {
                    //sorgu ugurla neticelenende
                    if (response.error == true) {

                        toastr.error(response.message, "Xəta baş verdi!");
                        return;
                    }
                    toastr.success(response.message, "Uğurla silindi!");
                    setTimeout(function () {
                        window.location.reload();
                    }, 1000)
                },
                error: function (response) {
                    //sorgu ugursuz neticelenende
  
                    toastr.error("Gözlənilməz xəta baş verdi", "Xəta!");
                }
            });
        }
    });
}
// 
function removeUserDocs(_id, _name, _path, elem) {

    swal({
        title: `Diqqət`,
        text: `Əminsiniz ki, '${_name}' siyahıdan silinsin?`,
        icon: "warning",
        buttons: ["Xeyr", "Bəli"],
        dangerMode: true,
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: 'get',
                url: _path,
                datatype: 'json',
                data: {
                    id: _id,
                },
                success: function (response) {
                    //sorgu ugurla neticelenende
                    if (response.error == true) {

                        toastr.error(response.message, "Xəta baş verdi!");
                        return;
                    }
                    toastr.success(response);
                    $(elem).parent().remove();
                },
                error: function (response) {
                    //sorgu ugursuz neticelenende
     
                    toastr.error("Gözlənilməz xəta baş verdi", "Xəta!");
                }
            });
        }
    });
}
// Remove confirmers from ticket  

function removeUserConfirm(_id, _name, _path, elem) {

    swal({
        title: `Diqqət`,
        text: `Əminsiniz ki, '${_name}' siyahıdan silinsin?`,
        icon: "warning",
        buttons: ["Xeyr", "Bəli"],
        dangerMode: true,
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: 'get',
                url: _path,
                datatype: 'json',
                data: {
                    id: _id,
                },
                success: function (response) {
                    //sorgu ugurla neticelenende
                    if (response.error == true) {

                        toastr.error(response.message, "Xəta baş verdi!");
                        return;
                    }
                    toastr.success("Təsdiqləyən siyahıdan silindi", "Uğur!");
                    $(elem).closest('li').remove();
                },
                error: function (response) {
                    //sorgu ugursuz neticelenende

                    toastr.error("Gözlənilməz xəta baş verdi", "Xəta!");
                }
            });
        }
    });
}
function removeUserTicketCheks(_id, _name, _path, elem) {

    swal({
        title: `Diqqət`,
        text: `Əminsiniz ki, '${_name}' siyahıdan silinsin?`,
        icon: "warning",
        buttons: ["Xeyr", "Bəli"],
        dangerMode: true,
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: 'get',
                url: _path,
                datatype: 'json',
                data: {
                    id: _id,
                },
                success: function (response) {
                    //sorgu ugurla neticelenende
                    if (response.error == true) {

                        toastr.error(response.message, "Xəta baş verdi!");
                        return;
                    }
                    toastr.success("Təsdiqləyən siyahıdan silindi", "Uğur!");
                    $(elem).closest('li').remove();
                },
                error: function (response) {
                    //sorgu ugursuz neticelenende

                    toastr.error("Gözlənilməz xəta baş verdi", "Xəta!");
                }
            });
        }
    });
}

function removeNewsImg(_id, _name, _path, elem) {

    swal({
        title: `Diqqət`,
        text: `Əminsiniz ki, '${_name}' siyahıdan silinsin?`,
        icon: "warning",
        buttons: ["Xeyr", "Bəli"],
        dangerMode: true,
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: 'get',
                url: _path,
                datatype: 'json',
                data: {
                    id: _id,
                },
                success: function (response) {
                    //sorgu ugurla neticelenende
                    if (response.error == true) {

                        toastr.error(response.message, "Xəta baş verdi!");
                        return;
                    }

                    $(elem).parent().parent().parent().remove();
                },
                error: function (response) {
                    //sorgu ugursuz neticelenende

                    toastr.error("Gözlənilməz xəta baş verdi", "Xəta!");
                }
            });
        }
    });
}

function removeNewsCategory(_newsId, _catId, _name, _path, elem) {

    var count_elements = $('.select2-selection__rendered li').length;
    if (count_elements <= 2) {
        toastr.error("Sonuncu xəbər kateqoriyası silinə bilməz Xəbərlərdə ən azı 1 kategoriya mövcud olmalıdır !");

    }
    else {

        swal({
            title: `Diqqət`,
            text: `Əminsiniz ki, '${_name}' siyahıdan silinsin?`,
            icon: "warning",
            buttons: ["Xeyr", "Bəli"],
            dangerMode: true,
        }).then((willDelete) => {
            if (willDelete) {
                $.ajax({
                    type: 'get',
                    url: _path,
                    datatype: 'json',
                    data: {
                        newsId: _newsId,
                        catId: _catId,
                    },
                    success: function (response) {
                        //sorgu ugurla neticelenende
                        if (response.error == true) {

                            toastr.error(response.message, "Xəta baş verdi!");
                            return;
                        }

                        $(elem).parent().remove();
                    },
                    error: function (response) {
                        //sorgu ugursuz neticelenende

                        toastr.error("Gözlənilməz xəta baş verdi", "Xəta!");
                    }
                });
            }
        });
    }
}