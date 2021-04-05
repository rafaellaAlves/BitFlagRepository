function IsNullOrWhiteSpace(input) {
    if (input == null) return true;
    if (input.length == 0) return true;
    return !input || !input.trim();
}

function ReplaceDots(value) {
    if (value.indexOf('.') != -1) {
        value = value.replace('.', ',');
    }
    return value;
}

function MoneyToFloat(value) {
    if (value == null || value == '') return 0;
    if (value.indexOf('.') != -1)
        value = value.replace(/\./g, '');
    if (value.indexOf(',') != -1)
        value = value.replace(',', '.');

    return value == null ? 0 : Globalize.parseFloat(value);
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

function _MaskData() {
    $('.quota').mask('#,0', { reverse: true });
    $('._date').mask('00/00/0000');
    $('.date').mask('00/00/0000');
    $('.date').datepicker({ format: 'dd/mm/yyyy', language: 'pt-BR', autoclose: true });
    $('.time').mask('00:00:00');
    $('.date-time').mask('00/00/0000 00:00:00');
    $('.monthYear').mask('00/0000');
    $('.monthYear').datepicker({ format: 'mm/yyyy', startView: "year", minViewMode: "months", language: 'pt-BR', autoclose: true });
    $('.cep').mask('00000-000');
    $('.mobile').mask('(00) #0000-0000');
    $('.phone').mask('(00) 0000-0000');
    $('.percent5').mask('##0,00000', { reverse: true });
    $('.percent2').mask('##0,00', { reverse: true });
    $('.percent4').mask('0,0000#', {
        onKeyPress: function (val, e, field, options) {
            var masks = ['0,0000#', '00,0000#', '000,0000'];
            var mask = val.length > 7 ? masks[2] : (val.length > 6 ? masks[1] : masks[0]);
            $('.percent4').mask(mask, options);
        }
    });

    $('.cnpj').mask('00.000.000/0000-00', { reverse: true, clearIfNotMatch: true });
    $('.cpf').mask('000.000.000-00', { reverse: true, clearIfNotMatch: true });
    $('._cpf').mask('#000.000.000-00', { reverse: true, clearIfNotMatch: true });
    $('.money').mask('#.##0,00', { reverse: true });
    $('.placa').mask('SSS-0000');
    $('.fipe').mask('000000-0');
    $('.renavam').mask('00000000-0');
    $('.year').mask('0000');
    $('.rg').mask('00.000.000-00');
    $('.number').mask('#');
}
$(function () {
    Globalize.culture('pt-BR');

    _MaskData();
    //$('.dataTables_length select').select2({ minimumResultsForSearch: Infinity });
});