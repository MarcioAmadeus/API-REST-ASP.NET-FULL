function setCookie(cname, cvalue, exdays) {
    var d = new Date();
    d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
    var expires = "expires=" + d.toUTCString();
    var domain = (location.hostname == "localhost" ? "" :
        location.hostname) + "; path=/";
    document.cookie = cname + "=" + cvalue + ";" + expires + ";domain=" + domain;
}

function getCookie(cname) {
    var name = cname + "=";
    var ca = document.cookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') {
            c = c.substring(1);
        }
        if (c.indexOf(name) == 0) {
            return c.substring(name.length, c.length);
        }
    }
    return "";
}

$(document).ready(function () {

    /* dataTable_with_no_ordering */
    /* dataTable_with_no_ordering */
    /* dataTable_with_no_ordering */

    var responsiveHelper_dt_basic = undefined;
    var responsiveHelper_datatable_fixed_column = undefined;
    var responsiveHelper_datatable_col_reorder = undefined;
    var responsiveHelper_datatable_tabletools = undefined;

    var breakpointDefinition = {
        tablet: 1024,
        phone: 480
    };

    $('.dataTable_with_no_ordering').dataTable({
        "sDom": "<'dt-toolbar'<'col-xs-12 col-sm-6'f><'col-sm-6 col-xs-12 hidden-xs'l>r>" +
            "t" +
            "<'dt-toolbar-footer'<'col-sm-6 col-xs-12 hidden-xs'i><'col-xs-12 col-sm-6'p>>",
        "autoWidth": true,
        "ordering": false,
        "filter": false,
        "oLanguage": {
            "sProcessing": "Processando...",
            "sLengthMenu": "Mostrando _MENU_ registro(s)",
            "sZeroRecords": "Nenhum registro correspondente foi encontrado",
            "sEmptyTable": "Nenhum registro na tabela",
            "sInfo": "Mostrando _START_ a _END_ de _TOTAL_ registro(s)",
            "sInfoEmpty": "Mostrando 0 a 0 de 0 registro(s)",
            "sInfoFiltered": "(filtrado de _MAX_ total de registro(s))",
            "sInfoPostFix": "",
            "sSearch": "Buscar ",
            "sUrl": "",
            "sInfoThousands": ",",
            "sLoadingRecords": "Carregando...",
            "oPaginate": {
                "sFirst": "Primeiro",
                "sLast": "Último",
                "sNext": "Seguinte",
                "sPrevious": "Anterior"
            },
            "oAria": {
                "sSortAscending": ": Ativar para ordenar a coluna de maneira ascendente",
                "sSortDescending": ": Ativar para ordenar a coluna de maneira descendente"
            }
        }
    });

    /* dt_basic */
    /* dt_basic */
    /* dt_basic */

    $('#dt_basic').dataTable({
        "sDom": "<'dt-toolbar'<'col-xs-12 col-sm-6'f><'col-sm-6 col-xs-12 hidden-xs'l>r>" +
            "t" +
            "<'dt-toolbar-footer'<'col-sm-6 col-xs-12 hidden-xs'i><'col-xs-12 col-sm-6'p>>",
        "autoWidth": true,
        "preDrawCallback": function () {
            // Initialize the responsive datatables helper once.
            if (!responsiveHelper_dt_basic) {
                responsiveHelper_dt_basic = new ResponsiveDatatablesHelper($('#dt_basic'), breakpointDefinition);
            }
        },
        "rowCallback": function (nRow) {
            responsiveHelper_dt_basic.createExpandIcon(nRow);
        },
        "drawCallback": function (oSettings) {
            responsiveHelper_dt_basic.respond();
        },
        "oLanguage": {
            "sProcessing": "Processando...",
            "sLengthMenu": "Mostrando _MENU_ registro(s)",
            "sZeroRecords": "Nenhum registro correspondente foi encontrado",
            "sEmptyTable": "Nenhum registro na tabela",
            "sInfo": "Mostrando _START_ a _END_ de _TOTAL_ registro(s)",
            "sInfoEmpty": "Mostrando 0 a 0 de 0 registro(s)",
            "sInfoFiltered": "(filtrado de _MAX_ total de registro(s))",
            "sInfoPostFix": "",
            "sSearch": "Buscar ",
            "sUrl": "",
            "sInfoThousands": ",",
            "sLoadingRecords": "Carregando...",
            "oPaginate": {
                "sFirst": "Primeiro",
                "sLast": "Último",
                "sNext": "Seguinte",
                "sPrevious": "Anterior"
            },
            "oAria": {
                "sSortAscending": ": Ativar para ordenar a coluna de maneira ascendente",
                "sSortDescending": ": Ativar para ordenar a coluna de maneira descendente"
            }
        }
    });

    $('.dt_basic').dataTable({
        "sDom": "<'dt-toolbar'<'col-xs-12 col-sm-6'f><'col-sm-6 col-xs-12 hidden-xs'l>r>" +
            "t" +
            "<'dt-toolbar-footer'<'col-sm-6 col-xs-12 hidden-xs'i><'col-xs-12 col-sm-6'p>>",
        "autoWidth": true,
        "ordering": false,
        "filter": true,
        "oLanguage": {
            "sProcessing": "Processando...",
            "sLengthMenu": "Mostrando _MENU_ registro(s)",
            "sZeroRecords": "Nenhum registro correspondente foi encontrado",
            "sEmptyTable": "Nenhum registro na tabela",
            "sInfo": "Mostrando _START_ a _END_ de _TOTAL_ registro(s)",
            "sInfoEmpty": "Mostrando 0 a 0 de 0 registro(s)",
            "sInfoFiltered": "(filtrado de _MAX_ total de registro(s))",
            "sInfoPostFix": "",
            "sSearch": "Buscar ",
            "sUrl": "",
            "sInfoThousands": ",",
            "sLoadingRecords": "Carregando...",
            "oPaginate": {
                "sFirst": "Primeiro",
                "sLast": "Último",
                "sNext": "Seguinte",
                "sPrevious": "Anterior"
            },
            "oAria": {
                "sSortAscending": ": Ativar para ordenar a coluna de maneira ascendente",
                "sSortDescending": ": Ativar para ordenar a coluna de maneira descendente"
            }
        }
    });

    /* mensagemTable */
    /* mensagemTable */
    /* mensagemTable */

    /* END BASIC */
    $('#mensagemTable').dataTable({
        "ordering": false,
        "filter": false,
        "bLengthChange": false,
        "oLanguage": {
            "sProcessing": "Processando...",
            "sLengthMenu": "Mostrando _MENU_ registro(s)",
            "sZeroRecords": "Nenhum registro correspondente foi encontrado",
            "sEmptyTable": "Nenhum registro na tabela",
            "sInfo": "Mostrando _START_ a _END_ de _TOTAL_ registro(s)",
            "sInfoEmpty": "Mostrando 0 a 0 de 0 registro(s)",
            "sInfoFiltered": "(filtrado de _MAX_ total de registro(s))",
            "sInfoPostFix": "",
            "sSearch": "Buscar:",
            "sUrl": "",
            "sInfoThousands": ",",
            "sLoadingRecords": "Carregando...",
            "oPaginate": {
                "sFirst": "Primeiro",
                "sLast": "Último",
                "sNext": "Seguinte",
                "sPrevious": "Anterior"
            },
            "oAria": {
                "sSortAscending": ": Ativar para ordenar a coluna de maneira ascendente",
                "sSortDescending": ": Ativar para ordenar a coluna de maneira descendente"
            }
        }
    });

    /* datatable_fixed_column */
    /* datatable_fixed_column */
    /* datatable_fixed_column */

    /* COLUMN FILTER  */
    var otable = $('#datatable_fixed_column').DataTable({
        "sDom": "t" +
                "<'dt-toolbar-footer'<'col-sm-6 col-xs-12 hidden-xs'i><'col-xs-12 col-sm-6'p>>",
        "autoWidth": true,
        "preDrawCallback": function () {
            // Initialize the responsive datatables helper once.
            if (!responsiveHelper_datatable_fixed_column) {
                responsiveHelper_datatable_fixed_column = new ResponsiveDatatablesHelper($('#datatable_fixed_column'), breakpointDefinition);
            }
        },
        "rowCallback": function (nRow) {
            responsiveHelper_datatable_fixed_column.createExpandIcon(nRow);
        },
        "drawCallback": function (oSettings) {
            responsiveHelper_datatable_fixed_column.respond();
        },
        "oLanguage": {
            "sProcessing": "Processando...",
            "sLengthMenu": "Mostrando _MENU_ registro(s)",
            "sZeroRecords": "Nenhum registro correspondente foi encontrado",
            "sEmptyTable": "Nenhum registro na tabela",
            "sInfo": "Mostrando _START_ a _END_ de _TOTAL_ registro(s)",
            "sInfoEmpty": "Mostrando 0 a 0 de 0 registro(s)",
            "sInfoFiltered": "(filtrado de _MAX_ total de registro(s))",
            "sInfoPostFix": "",
            "sSearch": "Buscar:",
            "sUrl": "",
            "sInfoThousands": ",",
            "sLoadingRecords": "Carregando...",
            "oPaginate": {
                "sFirst": "Primeiro",
                "sLast": "Último",
                "sNext": "Seguinte",
                "sPrevious": "Anterior"
            },
            "oAria": {
                "sSortAscending": ": Ativar para ordenar a coluna de maneira ascendente",
                "sSortDescending": ": Ativar para ordenar a coluna de maneira descendente"
            }
        }
    });

    // Apply the filter
    $("#datatable_fixed_column thead th input[type=text]").on('keyup change', function () {

        otable
            .column($(this).parent().index() + ':visible')
            .search(this.value)
            .draw();
    });

    /* datatable_fixed_column */
    /* datatable_fixed_column */
    /* datatable_fixed_column */

    /* COLUMN FILTER  */
    var otable2 = $('.datatable_fixed_column').DataTable({
        "sDom": "t" +
                "<'dt-toolbar-footer'<'col-sm-6 col-xs-12 hidden-xs'i><'col-xs-12 col-sm-6'p>>",
        "autoWidth": true,
        "oLanguage": {
            "sProcessing": "Processando...",
            "sLengthMenu": "Mostrando _MENU_ registro(s)",
            "sZeroRecords": "Nenhum registro correspondente foi encontrado",
            "sEmptyTable": "Nenhum registro na tabela",
            "sInfo": "Mostrando _START_ a _END_ de _TOTAL_ registro(s)",
            "sInfoEmpty": "Mostrando 0 a 0 de 0 registro(s)",
            "sInfoFiltered": "(filtrado de _MAX_ total de registro(s))",
            "sInfoPostFix": "",
            "sSearch": "Buscar:",
            "sUrl": "",
            "sInfoThousands": ",",
            "sLoadingRecords": "Carregando...",
            "oPaginate": {
                "sFirst": "Primeiro",
                "sLast": "Último",
                "sNext": "Seguinte",
                "sPrevious": "Anterior"
            },
            "oAria": {
                "sSortAscending": ": Ativar para ordenar a coluna de maneira ascendente",
                "sSortDescending": ": Ativar para ordenar a coluna de maneira descendente"
            }
        }
    });

    //// Apply the filter
    $(".datatable_fixed_column thead th input[type=text]").on('keyup change', function () {

        otable2
            .column($(this).parent().index() + ':visible')
            .search(this.value)
            .draw();

    });
    /* END COLUMN FILTER */

    if ($("#dt_basic").length > 0) {
        var dt_basic_length = getCookie("dt_basic_length");

        if (dt_basic_length != "") {
            $("select[name='dt_basic_length']").val(dt_basic_length);
        }

        $("select[name='dt_basic_length']").change(function () {
            var novoValor = $(this).val();
            setCookie("dt_basic_length", novoValor, 30);
        });

        $("#dt_basic_length label select.form-control").change();
    }

    if ($(".dataTable_with_no_ordering").length > 0) {
        var dt_basic_length = getCookie("dt_basic_length");

        if (dt_basic_length != "") {
            $("table.dataTable_with_no_ordering").prev().find('select').val(dt_basic_length);
        }

        $("table.dataTable_with_no_ordering").prev().find('select').change(function () {
            var novoValor = $(this).val();
            setCookie("dt_basic_length", novoValor, 30);
        });

        $("table.dataTable_with_no_ordering").prev().find('select').change();
    }

    if ($(".dt_basic").length > 0) {
        var dt_basic_length = getCookie("dt_basic_length");

        if (dt_basic_length != "") {
            $("table.dt_basic").prev().find('select').val(dt_basic_length);
        }

        $("table.dt_basic").prev().find('select').change(function () {
            var novoValor = $(this).val();
            setCookie("dt_basic_length", novoValor, 30);
        });

        $("table.dt_basic").prev().find('select').change();
    }
});