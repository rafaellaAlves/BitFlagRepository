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

function validateInputs(parent) {
    if (IsNullOrWhiteSpace(parent)) $('.text-danger').remove();
    else $(parent + ' .text-danger').remove();

    var hasError = false;
    var elements = $('.required + input:visible, .required + select:visible, .required + textarea:visible, .required + .input-group > input:visible, .required + .input-group > select:visible, .required + .input-group > textarea:visible, input.required, select.required:visible, textarea.required:visible');

    if (!IsNullOrWhiteSpace(parent))
        elements = $(parent).find('.required + input:visible, .required + select:visible, .required + textarea:visible, .required + .input-group > input:visible, .required + .input-group > select:visible, .required + .input-group > textarea:visible, input.required:visible, select.required:visible, textarea.required:visible');

    $.each(elements, function (i, e) {
        var input = $(e);
        var area = input.closest('.input-group');
        area = area.length == 0 ? input : area;

        if (IsNullOrWhiteSpace(input.val())) {
            var message = IsNullOrWhiteSpace($(input).data('error-message')) ? 'Este campo deve ser preenchido.' : $(input).data('error-message');

            area.after($('<div>', { class: "text-danger", style: 'font-size: 11px;' }).append(message));
            hasError = true;
        }
    });

    return !hasError;
}

function ValidateCPF(strCPF) {
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

function clearAddressFields(enderecoField, bairroField, cidadeField, estadoField) {
    $(enderecoField).val('');
    $(bairroField).val('');
    $(cidadeField).val('');
    $(estadoField).val('');
}

(function ($) {
    $.extend($.summernote.lang, {
        'pt-BR': {
            font: {
                bold: 'Negrito',
                italic: 'Itálico',
                underline: 'Sublinhado',
                clear: 'Remover estilo da fonte',
                height: 'Altura da linha',
                name: 'Fonte',
                strikethrough: 'Riscado',
                size: 'Tamanho da fonte'
            },
            image: {
                image: 'Imagem',
                insert: 'Inserir imagem',
                resizeFull: 'Redimensionar Completamente',
                resizeHalf: 'Redimensionar pela Metade',
                resizeQuarter: 'Redimensionar um Quarto',
                floatLeft: 'Flutuar para Esquerda',
                floatRight: 'Flutuar para Direira',
                floatNone: 'NÃ£o Flutuar',
                dragImageHere: 'Arraste uma imagem para cá',
                selectFromFiles: 'Selecione a partir dos arquivos',
                url: 'URL da imagem'
            },
            video: {
                video: 'VÃ­deo',
                videoLink: 'Link para ví­deo',
                insert: 'Inserir vÃídeo',
                url: 'URL do vÃídeo?',
                providers: '(YouTube, Vimeo, Vine, Instagram, DailyMotion ou Youku)'
            },
            link: {
                link: 'Link',
                insert: 'Inserir link',
                unlink: 'Remover link',
                edit: 'Editar',
                textToDisplay: 'Texto para exibir',
                url: 'Para qual URL esse link leva?',
                openInNewWindow: 'Abrir em uma nova janela'
            },
            table: {
                table: 'Tabela'
            },
            hr: {
                insert: 'Inserir linha horizontal'
            },
            style: {
                style: 'Estilo',
                normal: 'Normal',
                blockquote: 'Citação',
                pre: 'Código',
                h1: 'Título 1',
                h2: 'Título 2',
                h3: 'Título 3',
                h4: 'Título 4',
                h5: 'Título 5',
                h6: 'Título 6'
            },
            lists: {
                unordered: 'Lista com marcadores',
                ordered: 'Lista numerada'
            },
            options: {
                help: 'Ajuda',
                fullscreen: 'Tela cheia',
                codeview: 'Ver código-fonte'
            },
            paragraph: {
                paragraph: 'Parágrafo',
                outdent: 'Menor tabulação',
                indent: 'Maior tabulação',
                left: 'Alinhar à esquerda',
                center: 'Alinhar ao centro',
                right: 'Alinha à direita',
                justify: 'Justificado'
            },
            color: {
                recent: 'Cor recente',
                more: 'Mais cores',
                background: 'Fundo',
                foreground: 'Fonte',
                transparent: 'Transparente',
                setTransparent: 'Fundo transparente',
                reset: 'Restaurar',
                resetToDefault: 'Restaurar padrão'
            },
            shortcut: {
                shortcuts: 'Atalhos do teclado',
                close: 'Fechar',
                textFormatting: 'Formatação de texto',
                action: 'Ação',
                paragraphFormatting: 'Formatação de parágrafo',
                documentStyle: 'Estilo de documento'
            },
            history: {
                undo: 'Desfazer',
                redo: 'Refazer'
            },
            help: {
                'insertParagraph': 'Inserir Parágrafo',
                'undo': 'Desfazer o último comando',
                'redo': 'Refazer o último comando',
                'tab': 'Tab',
                'untab': 'Desfazer tab',
                'bold': 'Colocar em negrito',
                'italic': 'Colocar em itálico',
                'underline': 'Sublinhado',
                'strikethrough': 'Tachado',
                'removeFormat': 'Remover estilo',
                'justifyLeft': 'Alinhar à esquerda',
                'justifyCenter': 'Centralizar',
                'justifyRight': 'Alinhar à esquerda',
                'justifyFull': 'Justificar',
                'insertUnorderedList': 'Lista não ordenada',
                'insertOrderedList': 'Lista ordenada',
                'outdent': 'Recuar parágrafo atual',
                'indent': 'AvanÃ§ar parágrafo atual',
                'formatPara': 'Alterar formato do bloco para parágrafo(tag P)',
                'formatH1': 'Alterar formato do bloco para H1',
                'formatH2': 'Alterar formato do bloco para H2',
                'formatH3': 'Alterar formato do bloco para H3',
                'formatH4': 'Alterar formato do bloco para H4',
                'formatH5': 'Alterar formato do bloco para H5',
                'formatH6': 'Alterar formato do bloco para H6',
                'insertHorizontalRule': 'Inserir régua horizontal',
                'linkDialog.show': 'Inserir um Hiperlink'
            }
        }
    });
})(jQuery);