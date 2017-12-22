//DO NOT REMOVE : GLOBAL FUNCTIONS
$(document).ready(function () {
    pageSetUp();

    if ($('.remover-menu-lateral').length) {
        $('#left-panel').hide();
        $('#main').css('margin-left', '0');
        $('.page-footer').css('padding-left', '0');
    }
});

function getParameterByName(name) {
    name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
    var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
        results = regex.exec(location.search);
    return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
}

$(document).ready(function () {

    var tabelaCentralizada = $(".tabelaCentralizada");
    if (tabelaCentralizada.length > 0) {
        var ocorrenciasSubstanciais = $(".painelSubstancial").length;
        var ocorrenciasNormais = $(".painelNormal").length;
        var ocorrenciasRenew = $(".painelRenew").length;
        var ocorrenciasPontoAtencao = $(".pontoAtencao").length;
        $(".ocorrencias-normais").html(" (" + ocorrenciasNormais + ")");
        $("#check-normal").prop('checked', $("#ExibirNormal").val() === "True" || $("#ExibirNormal").val() === 'true');
        $(".ocorrencias-substanciais").html(" (" + ocorrenciasSubstanciais + ")");
        $("#check-substancial").prop('checked', $("#ExibirSubstancial").val() === "True" || $("#ExibirSubstancial").val() === 'true');
        $(".ocorrencias-renew").html(" (" + ocorrenciasRenew + ")");
        $("#check-renew").prop('checked', $("#ExibirRenew").val() === "True" || $("#ExibirRenew").val() === 'true');
        $(".ocorrencias-ponto").html(" (" + ocorrenciasPontoAtencao + ")");
        $("#check-ponto").prop('checked', $("#ExibirPontoDeAtencao").val() === "True" || $("#ExibirPontoDeAtencao").val() === 'true');
    }

    $('.datepicker').datepicker({
        format: "dd/mm/yyyy",
        todayBtn: true,
        minDate: 0,
        autoclose: true,
        language: 'pt-BR',
        todayHighlight: true
    }).on('change', function () {
        $(this).valid();
    });

    var itensConhecimento = [
      "Alerta Técnico",
      "Lição Aprendida",
      "Prática",
    ];

    $("input.tagsItemConhecimento").autocomplete({
        source: itensConhecimento,
        minLength: 0
    }).focus(function () {
        $(this).autocomplete("search", $(this).val());
    });

    var tiposDiscussão = [
      "Pública",
      "Protegida",
    ];
    $("input.tagsTipoDiscussão").autocomplete({
        source: tiposDiscussão,
        minLength: 0
    }).focus(function () {
        $(this).autocomplete("search", $(this).val());
    });

    $(".menu-christino li.active").each(function () {
        $(this).parents("li").addClass("active");
    })

    url = "/Script/GetUserInfoAsync"
    $.ajax({
        type: 'POST',
        url: url,
        data: {},
        success: successFunc,
        error: errorFunc
    });

    function successFunc(data, status) {
        if (data) {
            var name = data.Nome;
            var url = data.ImagemUrl;
            $(".user-menu li:first").find("span").text(name);

            if (url != null) {
                $(".user-area").css("background-image", "url('" + url + "')");

                if (data.DataUltimoAcesso) {
                    var dataUltimoAcesso = data.DataUltimoAcesso.replace(')', '(').split("(")[1];
                    $("#prog_string").text(jQuery.timeago(new Date(parseInt(dataUltimoAcesso, 10))));
                }
            }
            else
                $(".user-area").css("background-image", "url('/content/img/avatars/sunny.png')");
        }
        else {
            errorFunc();
        }
    }

    function errorFunc() {
        $(".user-menu li:first").find("span").text("DESCONHECIDO");
        $(".user-area").css("background-image", "url('/content/img/avatars/sunny.png')");
    }

    $('.select2-hidden-accessible').hide()

    function VerificarChave() {
        $("#chaveTripulanteNote").hide();
        $("#enviarFormularioTripulante").prop("disabled", true);
        if ($("#chaveTripulante").length > 0) {
            if ($("#chaveTripulante").val().length == 4) {
                $.ajax
                ({
                    url: "/ConformidadeLegal/Tripulante/ValidarChaveTripulante/",
                    data: { valor: $("#chaveTripulante").val() },
                    success: function (data) {
                        if (data.length == 0) {
                            $("#enviarFormularioTripulante").prop("disabled", true);
                            $("#chaveTripulanteNote").empty();
                            $("#chaveTripulanteNote").append("<span class=\"text-danger\"><i class=\"fa fa-times-circle\"></i> Erro: Usuário não encontrado</span>")
                            $("#chaveTripulanteNote").show();
                        }
                        else {
                            $("#enviarFormularioTripulante").prop("disabled", false);
                            $("#chaveTripulanteNote").empty();
                            $("#chaveTripulanteNote").append("<span class=\"text-success\"><i class=\"fa fa-user\"></i> Usuário encontrado: " + data + "</span>");
                            $("#chaveTripulanteNote").show();
                        }
                    }
                })
            }
        }
    };

    VerificarChave();
    $("#chaveTripulante").on("input", function () {
        this.value = this.value.toUpperCase();
        VerificarChave();
    });

    $("body").bind("mousedown keydown", function (e) {
        if (!$("#modal_timeout").length) {
            var d = new Date();
            var min = d.getMinutes();
            var tempoOcioso = 10 * 60 * 1000; //10 min
            min += tempoOcioso;
            d.setMinutes(min);
            initializeClock(d, tempoOcioso);
        }
    });

    var timeinterval;
    function initializeClock(endtime, timeout) {
        clearTimeout(timeinterval);
        timeinterval = setTimeout(function () {
            var t = getTimeRemaining(endtime);
            if (t.total <= 0) {
                clearTimeout(timeinterval);
                if (!$("#modal_timeout").length) {
                    notifyTimeout();
                }
            }
        }, timeout);
    }

    function getTimeRemaining(endtime) {
        var t = Date.parse(endtime) - Date.parse(new Date());
        var seconds = Math.floor((t / 1000) % 60);
        var minutes = Math.floor((t / 1000 / 60) % 60);
        var hours = Math.floor((t / (1000 * 60 * 60)) % 24);
        var days = Math.floor(t / (1000 * 60 * 60 * 24));
        return {
            'total': t,
            'days': days,
            'hours': hours,
            'minutes': minutes,
            'seconds': seconds
        };
    }

    function notifyTimeout() {

        $("body").append($("<div>").attr("id", "modal_timeout").attr("data-toggle", "modal"));
        var $dialog = $("#modal_timeout");

        $dialog.dialog({
            autoOpen: true,
            position: { my: "center", at: "center", of: window },
            width: 300,
            resizable: false,
            title: "Aviso de tempo ocioso",
            load: notifyView($dialog),
            modal: true
        });

        $dialog.on("dialogclose", function () {
            $dialog.remove();
        });

        $("#close_modal_bt").click(function () {
            var $this = $(this).parent().parent();
            $this.remove();
        });
        return false;
    };

    function notifyView($this) {
        $this.append($("<div>").attr("class", "modal-body").text("Você está inativo por mais de 10 minutos!"));
        $this.append($("<div>").attr("class", "modal-footer").append($("<button>").text("OK").attr("id", "close_modal_bt").attr("class", "btn btn-default").attr("data-dismiss", "modal")));
    }
});

$(".data").mask("99/99/9999");
$(".telefone")
        .mask("(99) 9999-9999?9")
        .focusout(function (event) {
            var target, phone, element;
            target = (event.currentTarget) ? event.currentTarget : event.srcElement;
            phone = target.value.replace(/\D/g, '');
            element = $(target);
            element.unmask();
            if (phone.length > 10) {
                element.mask("(99) 99999-999?9");
            } else {
                element.mask("(99) 9999-9999?9");
            }
        });
$('.dinheiro').maskMoney({ allowNegative: true, thousands: '.', decimal: ',', affixesStay: false });
$('.decimal').maskMoney({ allowNegative: true, thousands: '.', decimal: ',', affixesStay: false });
$('.cnpj').mask('99.999.999/9999-99', { reverse: true });
$('.cpf').mask('999.999.999-99', { reverse: true });
$('.inteiro').maskMoney({ allowNegative: true, thousands: '.', decimal: ',', affixesStay: false, precision: 0 });


$(".cpfcnpj").keydown(function () {
    try {
        $(this).unmask();
    } catch (e) { }

    var tamanho = $(this).val().length;

    if (tamanho < 11) {
        $(this).mask("999.999.999-99");
    } else {
        $(this).mask("99.999.999/9999-99");
    }
});

$('.clockpicker').clockpicker({
    placement: 'top',
    donetext: 'Salvar'
});

$("#telefone").on("blur", function () {
    $(this).ajustPhoneMask();
});

$('#addItem').click(function () {
    $.ajax({
        url: this.href,
        cache: false,
        success: function (html) {
            $('#editorRows').append(html);
            var itens = document.getElementsByClassName("itens");
            $('#' + itens[itens.length - 1].id).select2();
        }
    });
    return false;
});

$('.addItem').click(function () {
    var $this = $(this);
    $.ajax({
        url: this.href,
        cache: false,
        success: function (html) {
            $this.parent().next("div").find(".editorRows tbody").append(html);
        }
    });
    return false;
});

$("body").on("click", ".deleteRow", function () {
    $(this).parents("tr.editorRow:first").remove();
    return false;
});

function showDatePicker() {
    $('.cursodatepicker').datepicker({
        format: "dd/mm/yyyy",
        todayBtn: true,
        language: 'pt-BR',
        forceParse: false,
        autoclose: true,
        todayHighlight: true,
        nextText: 'Próximo',
        prevText: 'Anterior'
    });
}

$('.input-group.date').datepicker({
    format: "dd/mm/yyyy",
    todayBtn: true,
    language: "pt-BR",
    forceParse: false,
    autoclose: true,
    todayHighlight: true
});


$(".spinner").spinner();

if ($('#spanUnidadeNome')) {
    if ($('li.liInstalacoes.active').length == 1) {
        $('#spanUnidadeNome').html('<i class="fa fa-chevron-right"></i> ' + $('li.liInstalacoes.active a').text());
    }
};

(function ($) {
    $.fn.datepicker.dates['pt-BR'] = {
        days: ["Domingo", "Segunda", "Terça", "Quarta", "Quinta", "Sexta", "Sábado", "Domingo"],
        daysShort: ["Dom", "Seg", "Ter", "Qua", "Qui", "Sex", "Sáb", "Dom"],
        daysMin: ["Do", "Se", "Te", "Qu", "Qu", "Se", "Sa", "Do"],
        months: ["Janeiro", "Fevereiro", "Março", "Abril", "Maio", "Junho", "Julho", "Agosto", "Setembro", "Outubro", "Novembro", "Dezembro"],
        monthsShort: ["Jan", "Fev", "Mar", "Abr", "Mai", "Jun", "Jul", "Ago", "Set", "Out", "Nov", "Dez"],
        today: "Hoje",
        clear: "Limpar"
    };
}(jQuery));

var startDate = new Date();
var FromEndDate = new Date();
var ToEndDate = new Date();

ToEndDate.setDate(ToEndDate.getDate() + 3650);

$('#startdate').datepicker({
    weekStart: 1,
    startDate: '01/01/1000',
    endDate: '01/01/2999',
    format: "dd/mm/yyyy",
    todayBtn: true,
    autoclose: true,
    todayHighlight: true,
    language: 'pt-BR',
})
    .on('changeDate', function (selected) {
        startDate = new Date(selected.date.valueOf());
        startDate.setDate(startDate.getDate(new Date(selected.date.valueOf())));
        $('#finishdate').datepicker('setStartDate', startDate);
    });

$('#finishdate')
    .datepicker({
        weekStart: 1,
        startDate: startDate,
        endDate: ToEndDate,
        format: "dd/mm/yyyy",
        todayBtn: true,
        autoclose: true,
        language: 'pt-BR',
        todayHighlight: true,
    })
    .on('changeDate', function (selected) {
        FromEndDate = new Date(selected.date.valueOf());
        FromEndDate.setDate(FromEndDate.getDate(new Date(selected.date.valueOf())));
        $('#startdate').datepicker('setEndDate', FromEndDate);
    });


(function ($) {
    jQuery.fn.ajustPhoneMask = function () {
        return this.each(function () {
            var last = $(this).val().substr($(this).val().indexOf("-") + 1);
            if (last.length == 3) {
                var move = $(this).val().substr($(this).val().indexOf("-") - 1, 1);
                var lastfour = move + last;
                var first = $(this).val().substr(0, 9);
                $(this).val(first + '-' + lastfour);
            }
        });
    };
})(jQuery);

$(".selectList").select2();

$('.selectListWithTags').select2({
    language: 'pt-BR',
    tags: true
});

showDatePicker();