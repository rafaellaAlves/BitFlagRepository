
$(document).ready(function () {
    document.getElementById('birthdate').max = new Date(new Date().getTime() - new Date().getTimezoneOffset() * 60000).toISOString().split("T")[0];

    //MASCARA
    $('input[name = CellphoneVet]').mask('(99) 99999-9999');

    //VALIDADE CELULAR
    jQuery.validator.addMethod('celular', function (value, element) {
        value = value.replace("(", "");
        value = value.replace(")", "");
        value = value.replace("-", "");
        value = value.replace(" ", "").trim();
        if (value == '00000000000') {
            return (this.optional(element) || false);
        } else if (value == '00000000000') {
            return (this.optional(element) || false);
        }
        if (["00", "01", "02", "03", , "04", , "05", , "06", , "07", , "08", "09", "10"]
            .indexOf(value.substring(0, 2)) != -1) {
            return (this.optional(element) || false);
        }
        if (value.length < 10 || value.length > 11) {
            return (this.optional(element) || false);
        }
        if (["6", "7", "8", "9"].indexOf(value.substring(2, 3)) == -1) {
            return (this.optional(element) || false);
        }
        return (this.optional(element) || true);
    }, 'Informe um celular válido.');


    //VALIDA O FORM
 
    $("#FormIndication").validate({
        onkeyup: function (element) {
            this.element(element);
        },
        onfocusout: function (element) {
            this.element(element);
        },
        rules: {
            FullName: {
                required: true,
                minlength: 5,
                maxlength: 30

            },
            BirthDate: {
                required: true
            },
            CRMV: {
                required: true,
                number: true
            },
            FullNameVet: {
                required: true,
                minlength: 5,
                maxlength: 30

            },
            FullNameVet2: {
                required: true,
                minlength: 5,
                maxlength: 30

            },
            CellphoneVet: {
                required: true,
                celular: true
            },
            CellphoneVet2: {
                required: true,
                celular: true
            },
            mensagem: {
                rangelength: [50, 1050],
            }
        },
        messages: {
            FullName: {
                required: "Este campo deve ser preenchido.",
                minlength: "Digite no mínimo 5 caracteres.",
                maxlength: "Digite no maxímo 30 caracteres."

            },
            BirthDate: {
                required: "Este campo deve ser preenchido."
            },
            CRMV: {
                required: "Este campo deve ser preenchido.",
                number: "Informe apenas números."
            },
            FullNameVet: {
                required: "Este campo deve ser preenchido.",
                minlength: "Digite no mínimo 5 caracteres.",
                maxlength: "Digite no maxímo 30 caracteres."

            },
            FullNameVet2: {
                required: "Este campo deve ser preenchido.",
                minlength: "Digite no mínimo 5 caracteres.",
                maxlength: "Digite no maxímo 30 caracteres."

            },
            CellphoneVet: {
                required: "Este campo deve ser preenchido."
            },
            CellphoneVet2: {
                required: "Este campo deve ser preenchido."
            }
        }
    });
});