$(document).ready(function () {
    var url = window.location.pathname;
    document.title = "Ticket Order Id " + url.substring(url.lastIndexOf('/') + 1);
    $('#procurement').DataTable(
        {
            "scrollX": true,
            "paging": false,
            "searching": false,
            "ordering": false,
            "order": [],
            "info": false,
            "responsive": false,
            "lengthChange": false,
            "autoWidth": true,
            "buttons": ["excel"]
        });


    $(document).on('click', '.dt-add', function (evt) {
        //Create some data and insert it

        var rowData = [];
        var table = $('#procurement').DataTable();
        var info = table.page.info();
        
        rowData.push('<button type="button" class="btn btn-danger btn-xs dt-delete btn-center"><span class="far fa-trash-alt" aria-hidden="true"></span></button>');
        rowData.push(`${info.recordsTotal + 1}`);
        rowData.push('');
        rowData.push('');
        rowData.push('');
        rowData.push('');
        rowData.push('');
        rowData.push('');
        rowData.push('');
        rowData.push('');
        rowData.push('');
        table.row.add(rowData).draw(false);
        //table.buttons().container().appendTo('#procurement_wrapper');
        $('.dt-delete').off('click');

        $('.dt-delete').each(function () {
            $(this).on('click', function (evt) {
                $this = $(this);

                var dtRow = $this.parents('tr');

                swal({
                    title: `Məlumat`,
                    text: `Bu sətri silmək istəyirsiniz?`,
                    icon: "info",
                    buttons: ["Xeyr", "Bəli"],
                    dangerMode: true,

                })
                    .then((will) => {
                        if (will) {
                            var table = $('#procurement').DataTable();
                            table.row(dtRow[0].rowIndex - 1).remove().draw(false);
                        }
                    });
            });
        });
    });

    $(document).on('click', 'td:not(:has(button))', function () {
        $(this).attr('contenteditable', 'true');
        var el = $(this);
        el.focus();

        $(this).blur(endEdition);

    });
    function endEdition() {
        var el = $(this);
        el.attr('contenteditable', 'false');
        el.off('blur', endEdition);

    }

    endEdition();

    $(document).on('mouseleave', '#procurementTable', function (e) {

        $('#Sales').val($('#procurementTable').html());

        console.log();

    })

});

