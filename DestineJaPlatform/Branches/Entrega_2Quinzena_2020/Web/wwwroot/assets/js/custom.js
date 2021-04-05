$(document).ajaxStart(function () {
    showLoading();
});
$(document).ajaxStop(function () {
    $("#loading").hide();
});
$(document).ajaxError(function () {
    $("#loading").hide();
    alert('Houve um erro ao processar sua solicitação.');
});

function showLoading() {
    $("#loading").show();
}
function hideLoading() {
    $("#loading").hide();
    InitializeFunctions();
}

function InitializeFunctions() {
    $('.cpf').mask('000.000.000-00');
    $('.rg').mask('00.000.000-0', { reverse: true });
    $('.cnh').mask('000000000-00', { reverse: true });
    $('.cnpj').mask('00.000.000/0000-00', { reverse: true });
    $('.money').mask('#.##0,00', { reverse: true });
    $('.date').mask('00/00/0000', { clearIfNotMatch: true });
    $('.month-datepicker').mask('00/0000', { clearIfNotMatch: true });
    $('.year').mask('9999', { clearIfNotMatch: true });
    $('.time').mask('99:99:99');
    $('.time-2').mask('99:99');
    $('.cep').mask('00000-000');
    $('.number').mask('#');
    $('.weight').mask('#0,000');
    $('.demand-mask').mask('0000/0000', { clearIfNotMatch: true });

    $('.phone-mask').mask('(00) 0000-0000');
    $('.mobile-mask').mask('(00) 00000-0000');

    $('.date').datepicker({ format: 'dd/mm/yyyy', language: 'pt-BR', autoclose: true });
    $('.month-datepicker').datepicker({ format: 'mm/yyyy', minViewMode: 1, language: 'pt-BR', autoclose: true });
    $('.year').datepicker({ format: 'yyyy', minViewMode: 2, language: 'pt-BR', autoclose: true });

    //$('.date').datepicker({
    //    format: 'dd/mm/yyyy',
    //    language: 'pt-BR',
    //    autoclose: true,
    //    orientation: 'auto bottom'
    //});
    //$('.date-range').datepicker({
    //    language: 'pt-BR',
    //    dateFormat: 'dd/mm/yyyy',
    //    range: true,
    //    multipleDatesSeparator: ' - '
    //});
    //$('.date-range-month').datepicker({
    //    language: 'pt-BR',
    //    dateFormat: 'MM yyyy',
    //    range: true,
    //    minView: 'months',
    //    view: 'months',
    //    multipleDatesSeparator: ' - '
    //});

    $('.cnpj, .cpf').change(function () {
        var val = $(this).val().replace(/\D/g, '');
        $('.document-error').remove();

        var length = 0;
        if ($(this).hasClass('cpf')) length = 11;
        if ($(this).hasClass('cnpj')) length = 14;

        if (val.length === length) return;

        //$(this).val('');
        $(this).after('<div class="text-danger document-error">Este campo não foi preenchido corretamente.</div>');
    });

    $(".cpfcnpj").keydown(function (e) {
        var digit = e.key.replace(/\D/g, '');

        var value = $(this).val().replace(/\D/g, '');

        var size = value.concat(digit).length;

        $(this).mask((size <= 11) ? '000.000.000-00' : '00.000.000/0000-00');
    });
}

$(document).ready(InitializeFunctions);

try {
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
} catch{ }

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
                className: 'btn-danger mr-auto float-left'
            }
        },
        callback: callback
    });
}

function successMessage(message) {
    var row = $('<div>', { class: 'row' });
    var col = $('<div>', { class: 'col-md-12' });
    var div = $('<div>', { class: 'alert alert-success alert-dismissible fade show', role: 'altert' });
    var span = $('<span>').append(isNullOrWhiteSpace(message) ? 'Item salvo com sucesso. Caso queira inserir outro, clique em adicionar.' : message);

    var button = $('<button>', { type: "button", class: "close" });
    button.attr('data-dismiss', "alert");
    button.attr('aria-label', "Close");
    button.append('<span aria-hidden="true">×</span>');

    row.append(col.append(div.append(span, button)));
    setTimeout(function () { row.fadeOut(2000) }, 8000);

    return row;
}

function isNullOrWhiteSpace(val) {
    if (val === null || val === undefined) return true;
    val = val.toString();

    val = val.replace(/\s+/g, '');
    return val === '';
}

function validateInputs(parent) {
    if (isNullOrWhiteSpace(parent)) $('.text-danger').remove();
    else $('#' + parent + ' .text-danger').remove();

    var hasError = false;
    var elements = $('.required + input:visible, .required + select:visible, .required + textarea:visible, .required + .input-group > input:visible, .required + .input-group > select:visible, .required + .input-group > textarea:visible, input.required, select.required:visible, textarea.required:visible'); //, .required + select:visible + .select2-container

    if (!isNullOrWhiteSpace(parent))
        elements = $('#' + parent).find('.required + input:visible, .required + select:visible, .required + textarea:visible, .required + .input-group > input:visible, .required + .input-group > select:visible, .required + .input-group > textarea:visible, input.required:visible, select.required:visible, textarea.required:visible'); //, .required + select:visible + .select2-container

    //elements = elements.toArray().filter(function (val) {
    //    return $('.required + select:visible + .select2-container').prev('select').toArray().indexOf(val) == -1;// remove selects quando é utilizado select2 (select2 é um span e não um select)
    //});

    $.each(elements, function (i, e) {
        var input = $(e);
        var area = input.closest('.input-group');
        area = area.length == 0 ? ((input.data('target') != null) ? $(input.data('target')) : input) : area;

        if (isNullOrWhiteSpace(input.val())) {
            var message = isNullOrWhiteSpace($(input).data('error-message')) ? 'Este campo deve ser preenchido.' : $(input).data('error-message');

            area.after($('<small>', { class: "text-danger", style: 'font-size: 11px;' }).append(message));
            hasError = true;
        }
    });

    return !hasError;
}

function getCompanyBySintegra(cnpjField, companyNameField, tradeNameField, ieField, cepField, enderecoField, bairroField, cidadeField, estadoField, complementField, numberField) {
    $('.CNPJError').remove();

    var cnpj = $(cnpjField).val().replace(/\D/g, '');
    if (cnpj != "") {

        var valida = /^[0-9]{14}$/;
        if (valida.test(cnpj)) {

            clearCompanyFields(companyNameField, tradeNameField, ieField);

            $.post("/Client/GetCompanyByCNPJ", { cnpj }, function (d) {
                if (d.status == "OK") {
                    $(companyNameField).val(d.nome_empresarial);
                    $(tradeNameField).val(d.nome_fantasia);
                    $(ieField).val(d.inscricao_estadual);
                    $(enderecoField).val(d.logradouro);


                    if ($(enderecoField).length > 0) $(enderecoField).val(d.logradouro);
                    if ($(cidadeField).length > 0) $(cidadeField).val(d.municipio);
                    if ($(estadoField).length > 0) $(estadoField).val(d.uf);
                    if ($(complementField).length > 0) $(complementField).val(d.complemento);
                    if ($(numberField).length > 0) $(numberField).val(d.numero);

                    if ($(cepField).length > 0) {
                        $(cepField).val($('.cep').masked(d.cep));
                        getAddress(cepField, enderecoField, bairroField, cidadeField, estadoField);
                    }

                } else {
                    clearCompanyFields(companyNameField, tradeNameField, ieField, cepField, enderecoField, bairroField, cidadeField, estadoField, numberField);
                    //$(cnpj).after('<div class="text-danger CNPJError">' + d.message + '</div>');
                }
            });
        }
        else {
            clearCompanyFields(companyNameField, tradeNameField, ieField, cepField, enderecoField, bairroField, cidadeField, estadoField, numberField);
            $(cnpj).after('<div class="text-danger CNPJError">Formato de CNPJ inválido.</div>');
        }
    }
}

function clearCompanyFields(companyNameField, tradeNameField, ieField, cepField, enderecoField, bairroField, cidadeField, estadoField, numberField) {
    $(companyNameField).val('');
    $(tradeNameField).val('');
    $(ieField).val('');

    if ($(cepField).length > 0) {
        $(cepField).val('');
        $(enderecoField).val('');
        $(bairroField).val('');
        $(cidadeField).val('');
        $(estadoField).val('');
        $(numberField).val('');
    }
}

function getAddress(cepField, enderecoField, bairroField, cidadeField, estadoField) {
    var cep = $(cepField).val().replace(/\D/g, '');

    $('.CEPError').remove();
    if (cep != "") {
        var validacep = /^[0-9]{8}$/;

        if (validacep.test(cep)) {

            LimparCamposEndereco(enderecoField, bairroField, cidadeField, estadoField);

            $.getJSON("https://viacep.com.br/ws/" + cep + "/json/?callback=?", function (dados) {
                if (!("erro" in dados)) {
                    $(enderecoField).val(dados.logradouro);
                    $(bairroField).val(dados.bairro);
                    $(cidadeField).val(dados.localidade);
                    $(estadoField).val(dados.uf);
                } else {
                    LimparCamposEndereco(enderecoField, bairroField, cidadeField, estadoField);
                    $(cepField).after('<div class="text-danger CEPError">CEP não encontrado.</div>');
                }
            });
        }
        else {
            LimparCamposEndereco(enderecoField, bairroField, cidadeField, estadoField);
            $(cepField).after('<div class="text-danger CEPError">Formato de CEP inválido.</div>');
        }
    }
}

function LimparCamposEndereco(enderecoField, bairroField, cidadeField, estadoField) {
    $(enderecoField).val('');
    $(bairroField).val('');
    $(cidadeField).val('');
    $(estadoField).val('');
}

$('input[type="checkbox"]').on('change', function () {
    $(this).val($(this).val() == 'on' ? true : false);
});


var typingTimer = {};
var doneTypingIntervalBase = 1000;

function doneTyping(searchVal, table) {
    $(table).DataTable().search(searchVal).draw();
}

function initSearchDataTable() {
    $('input[data-toggle="search-datatable"]').on('keyup', function () {
        clearTimeout(doneTypingIntervalBase);

        var table = $(this).data('target');
        var searchVal = $(this).val();
        var timeout = $(this).data('timeout');

        typingTimer[table] = setTimeout(function () { doneTyping(searchVal, table); }, timeout ?? doneTypingIntervalBase);

    });
    $('input[data-toggle="search-datatable"]').on('keydown', function () {
        clearTimeout(typingTimer[$(this).data('target')]);
    });
}
$(document).ready(initSearchDataTable);

try {
    FilePond.setOptions({
        labelIdle: 'Arraste e Solte arquivos ou <span class="filepond--label-action">clique aqui</span>',
        labelInvalidField: 'Campo contem arquivo(s) inválido(s)',
        labelFileWaitingForSize: 'Aguardando pelo tamanho do arquivo',
        labelFileSizeNotAvailable: 'Tamanho não válido',
        labelFileLoading: 'Carregando',
        labelFileLoadError: 'Erro durante o carregamento',
        labelFileProcessing: 'Fazendo upload',
        labelFileProcessingComplete: 'Upload concluído',
        labelFileProcessingAborted: 'Upload cancelado',
        labelFileProcessingError: 'Erro durante o upload',
        labelFileProcessingRevertError: '',
        labelFileRemoveError: 'Erro durante remoção',
        labelTapToCancel: 'Toque para cancelar',
        labelTapToRetry: 'Toque para tentar novamente',
        labelTapToUndo: 'Toque para desfazer',
        labelButtonRemoveItem: 'Remover',
        labelButtonAbortItemLoad: 'Abortar',
        labelButtonRetryItemLoad: 'Tentar novamente',
        labelButtonAbortItemProcessing: 'Cancelar',
        labelButtonUndoItemProcessing: 'Desfazer',
        labelButtonRetryItemProcessing: 'Tentar novamente',
        labelButtonProcessItem: 'Upload'
    });
} catch{ }

function getDaysFromToday(dueDate) {
    if (dueDate == null) return 0;

    var now = new Date();
    now.setHours(0, 0, 0, 0);

    var difference_In_Time = dueDate.getTime() - now.getTime();

    return difference_In_Time / (1000 * 3600 * 24);
}

function formatDate(date, format) {
    return date == null ? '' : moment(date).format(format ?? 'DD/MM/YYYY');
}

function isNull(val1, val2) {
    return !isNullOrWhiteSpace(val1) ? val1 : val2;
}

function updateAddressFieldsSize() {
    $('.address-sm [name="CEP"]').closest('.col-md-2').removeClass('col-md-2').addClass('col-md-4');
    $('.address-sm [name="Address"]').closest('.col-md-6').removeClass('col-md-6').addClass('col-md-8');
    $('.address-sm [name="Number"]').closest('.col-md-2').removeClass('col-md-2').addClass('col-md-4');
    $('.address-sm [name="Complement"]').closest('.col-md-2').removeClass('col-md-2').addClass('col-md-8');
    $('.address-sm [name="Neighborhood"]').closest('.col-md-3').removeClass('col-md-3').addClass('col-md-6');
    $('.address-sm [name="City"]').closest('.col-md-4').removeClass('col-md-4').addClass('col-md-6');
    $('.address-sm [name="State"]').closest('.col-md-2').removeClass('col-md-2').addClass('col-md-6');
}

function disableFields(parent) {
    if (parent == null) {
        $('input, select, textarea, button').not('[data-disabled="false"]').attr('disabled', 'disabled');
        return;
    }

    $(parent + ' input, ' + parent + ' select, ' + parent + ' textarea, ' + parent + ' button').not('[data-disabled="false"]').attr('disabled', 'disabled');
}

function disableAllFields(parent, removeLinks) {
    if (parent == null) {
        $('input, select, textarea, button').not('[data-disabledAll="false"]').attr('disabled', 'disabled');

        if (removeLinks) $('a').not('[data-disabledAll="false"]').remove();
        else $('a').not('[data-disabledAll="false"]').removeAttr('href onclick');

        return;
    }

    $(parent + ' input, ' + parent + ' select, ' + parent + ' textarea, ' + parent + ' button').not('[data-disabledAll="false"]').attr('disabled', 'disabled');
    if (removeLinks) $(parent + ' a').not('[data-disabledAll="false"]').remove();
    else $(parent + ' a').not('[data-disabledAll="false"]').removeAttr('href onclick');

}

$(document).ready(updateAddressFieldsSize);

function constructModal() {
    $.each($('modal'), function (i, e) {
        var modal_id = $(e).attr('id');
        var modal_class = $(e).attr('class');
        var modal_title_id = $(e).attr('title-id');
        var modal_title = $(e).attr('title');
        var modal_lg = $(e).attr('modal-lg');
        var hide_footer = $(e).attr('hide-footer');

        var modal = $('<div>', { class: 'modal fade ' + modal_class, id: (modal_id === null ? '' : modal_id), tabindex: '-1', role: 'dialog', 'aria-labelledby': (modal_title_id === null ? '' : modal_title_id), 'aria-hidden': true });
        var modal_dialog = $('<div>', { class: 'modal-dialog ' + (modal_lg === 'true' ? 'modal-lg' : ''), role: 'document' });
        var modal_content = $('<div>', { class: 'modal-content' });

        var modal_header = $('<div>', { class: 'modal-header' }).append(
            $('<h5>', { class: 'modal-title tx-14 mg-b-0 tx-uppercase tx-inverse tx-bold', id: (modal_title_id === null ? '' : modal_title_id) }).append(modal_title),
            $('<button>', { type: 'button', class: 'close', 'data-dismiss': 'modal', 'aria-label': 'Close', 'data-disabled': false, 'data-disabledAll': "false" }).append('&times;')
        );

        var modal_body = $('<div>', { class: 'modal-body' }).append($(e).html());

        var modal_footer = $('<div>', { class: 'modal-footer' }).append(
            $('<div>', { class: 'col-12' }).append($('<button>', { type: 'button', class: 'btn btn-secondary', 'data-dismiss': 'modal', 'data-disabled': false, 'data-disabledAll': "false" }).append('<i class="simple-icon-close"></i>&nbsp;Fechar'))
        );

        modal_content.append(modal_header, modal_body);
        if (hide_footer !== 'true') modal_content.append(modal_footer);
        modal.append(modal_dialog.append(modal_content));

        $(e).before(modal);
        $(e).remove();
    });
}
$(document).ready(constructModal);

$(document).ready(function () {
    try { Globalize.culture("pt-BR"); } catch{ }
});

$.extend({
    distinct: function (anArray) {
        var result = [];
        $.each(anArray, function (i, v) {
            if ($.inArray(v, result) == -1) result.push(v);
        });
        return result;
    }
});

$('input').bind("keypress", function (e) {
    if (e.keyCode == 13) {
        e.preventDefault();
        return false;
    }
});


$('[data-toggle="slide"]').click(function () {
    var time = 400;
    var target = $(this).data('target');

    if ($(target).is(':visible')) {
        $(target).slideUp(time);
    } else {
        $(target).slideDown(time);
    }
});

function getListActionsLink(actions) {
    var r = '<ul class="nav justify-content-center p-0"><li class="nav-item dropdown"><a class="nav-link dropdown-toggle p-0" data-toggle="dropdown" href="#" role="button" aria-haspopup="true" aria-expanded="false" title="Clique aqui para visualizar as ações disponíveis."><i class="simple-icon-menu"></i></a><div class="dropdown-menu">';
    $.each(actions, function (i, e) {
        r += '<a href="' + e.link + '" class="dropdown-item">' + e.text + '</a>';
    });
    r += '</div></li></ul>';

    return r;
}