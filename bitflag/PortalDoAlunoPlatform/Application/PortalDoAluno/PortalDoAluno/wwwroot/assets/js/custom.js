$(document).ajaxStart(function () {
    $("#loading").show();
});
$(document).ajaxStop(function () {
    $("#loading").hide();
    InitializeFunctions();
});
$(document).ajaxError(function () {
    $("#loading").hide();
    alert('Houve um erro ao processar sua solicitação.');
});

function InitializeFunctions() {
    $('.phone').mask('(00) 0000-0000');
    $('.mobile-phone').mask('(00) 00000-0000');
    $('.year').mask('0000');
    $('.cep').mask('00000-000');
    $('.rg').mask('00.000.000-0', { reverse: true });
    $('.cpf').mask('000.000.000-00', { reverse: true });
    $('.money').mask('#.##0,00', { reverse: true });
    $('.date').mask('99/99/9999');
    $('.number').mask('#');

    $('.date').datepicker({
        format: 'dd/mm/yyyy',
        language: 'pt-BR',
        autoclose: true,
        orientation: 'auto bottom'
    });
    $('.date-range').datepicker({
        language: 'pt-BR',
        dateFormat: 'dd/mm/yyyy',
        range: true,
        multipleDatesSeparator: ' - '
    });
    $('.date-range-month').datepicker({
        language: 'pt-BR',
        dateFormat: 'MM yyyy',
        range: true,
        minView: 'months',
        view: 'months',
        multipleDatesSeparator: ' - '
    });
}

function isNullOrWhiteSpace(val)
{
    if (val == null) return true;

    val = val.replace(/\s+/g, '');
    return val == '';
}

function validateInputs(parent)
{
    if (isNullOrWhiteSpace(parent)) $('.text-danger').remove();
    else $('#' + parent + ' .text-danger').remove();

    var hasError = false;
    var elements = $('.required + input, .required + select, .required + textarea, .required + .input-group > input, .required + .input-group > select, .required + .input-group > textarea');;

    if (!isNullOrWhiteSpace(parent))
        elements = $('#' + parent).find('.required + input, .required + select, .required + textarea, .required + .input-group > input, .required + .input-group > select, .required + .input-group > textarea');

    $.each(elements, function (i, e) {
        var input = $(e);
        var area = input.closest('.input-group');
        area = area.length == 0? input : area;

        if (isNullOrWhiteSpace(input.val())) {
            area.after($('<div>', { class: "text-danger", style: 'font-size: 11px;' }).append('Este campo deve ser preenchido.'));
            hasError = true;
        }
    });

    return !hasError;
}

$.extend(true, $.fn.dataTable.defaults, {
    "iDisplayLength": 10,
    'language': {
        "sEmptyTable": "Nenhum registro encontrado",
        "sInfo": "Mostrando de _START_ até _END_ de _TOTAL_ registros",
        "sInfoEmpty": "Mostrando 0 até 0 de 0 registros",
        "sInfoFiltered": "(Filtrados de _MAX_ registros)",
        "sInfoPostFix": "",
        "sInfoThousands": ".",
        "sLengthMenu": "_MENU_ resultados por página",
        "sLoadingRecords": "Carregando...",
        "sProcessing": "Processando...",
        "sZeroRecords": "Nenhum registro encontrado",
        "sSearch": "Pesquisar",
        "oPaginate": {
            "sNext": "Próximo",
            "sPrevious": "Anterior",
            "sFirst": "Primeiro",
            "sLast": "Último"
        },
        "oAria": {
            "sSortAscending": ": Ordenar colunas de forma ascendente",
            "sSortDescending": ": Ordenar colunas de forma descendente"
        }
    }
});

function bootboxConfirm(title, callback) {
    bootbox.confirm({
        message: title,
        buttons: {
            confirm: {
                label: 'Sim',
                className: 'btn-success'
            },
            cancel: {
                label: 'Não',
                className: 'btn-danger'
            }
        },
        callback: callback
    });
}


function getAddress(cepField, enderecoField, bairroField, cidadeField, estadoField) {
    var cep = $(cepField).val().replace(/\D/g, '');

    $('.CEPError').remove();
    if (cep != "") {
        var validacep = /^[0-9]{8}$/;

        if (validacep.test(cep)) {
            clearAddressFields(enderecoField, bairroField, cidadeField, estadoField);

            $.getJSON("https://viacep.com.br/ws/" + cep + "/json/?callback=?", function (dados) {
                if (!("erro" in dados)) {
                    $(enderecoField).val(dados.logradouro);
                    $(bairroField).val(dados.bairro);
                    $(cidadeField).val(dados.localidade);
                    $(estadoField).val(dados.uf);
                } else {
                    clearAddressFields(enderecoField, bairroField, cidadeField, estadoField);
                    $(cepField).after('<div class="text-danger CEPError">CEP não encontrado.</div>');
                }
            });
        }
        else {
            clearAddressFields(enderecoField, bairroField, cidadeField, estadoField);
            $(cepField).after('<div class="text-danger CEPError">Formato de CEP inválido.</div>');
        }
    }
}

function clearAddressFields(fields) {
    $.each(function (i, e) { $(e).val(''); });
}


function validateCPF(strCPF) {
    strCPF = strCPF.replace(/\D/g, '');

    var Soma;
    var Resto;
    Soma = 0;

    if (strCPF == "00000000000" || strCPF == '11111111111' || strCPF == '22222222222' || strCPF == '33333333333' || strCPF == '44444444444' || strCPF == '55555555555' || strCPF == '66666666666' || strCPF == '77777777777' || strCPF == '88888888888' || strCPF == '99999999999')
        return false;
    for (i = 1; i <= 9; i++)
        Soma = Soma + parseInt(strCPF.substring(i - 1, i)) * (11 - i);
    Resto = (Soma * 10) % 11;
    if ((Resto == 10) || (Resto == 11))
        Resto = 0;
    if (Resto != parseInt(strCPF.substring(9, 10)))
        return false;
    Soma = 0;
    for (i = 1; i <= 10; i++)
        Soma = Soma + parseInt(strCPF.substring(i - 1, i)) * (12 - i);
    Resto = (Soma * 10) % 11;
    if ((Resto == 10) || (Resto == 11))
        Resto = 0;
    if (Resto != parseInt(strCPF.substring(10, 11)))
        return false;
    return true;
}