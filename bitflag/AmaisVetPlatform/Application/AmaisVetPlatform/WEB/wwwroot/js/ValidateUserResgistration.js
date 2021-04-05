$(document).ready(function () {

    //VALIDA MODAL ATUALIZAÇÃO DE CAPTAÇÃO DO VENDEDOR
    $('input[name = MobilephoneSaller]').mask('(99) 99999-9999');

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


    $("#form-update-fundclient").validate({
        onkeyup: function (element) {
            this.element(element);
        },
        onfocusout: function (element) {
            this.element(element);
        },
        rules: {
            Name: {
                required: true,
                minlength: 5,
                maxlength: 20
            },
            DDD: {
                required: true,
                number: true
            },
            MobilephoneSaller: {
                required: true,
                celular: true
            },
            mensagem: {
                rangelength: [50, 1050],
            }
        },
        messages: {
            Name: {
                required: "Este campo deve ser preenchido.",
                minlength: "Digite no mínimo 5 caracteres.",
                maxlength: "Digite no maxímo 20 caracteres."
            },
            DDD: {
                required: "Digite um email válido.",
                number: "Digite apenas números."
            },
            MobilephoneSaller: {
                required: "Este campo deve ser preenchido."
            },
            mensagem: {
                required: "D",
                minlength: "Mínimo de caracteres permitidos 50",
                maxlength: "Maxímo de caracteres permitidos 1050"
            },

        }
    });


    //VALIDA SENHA
    var myInput = document.getElementById("Password");
    var capital = document.getElementById("capital");
    var number = document.getElementById("number");
    var length = document.getElementById("length");


    myInput.onfocus = function () {
        document.getElementById("message").style.display = "block";
    }

    myInput.onblur = function () {
        document.getElementById("message").style.display = "none";
    }

    myInput.onkeyup = function () {
       

        // Validate capital letters
        var upperCaseLetters = /[A-Z]/g;
        if (myInput.value.match(upperCaseLetters)) {
            capital.classList.remove("invalid");
            capital.classList.add("valid");
        } else {
            capital.classList.remove("valid");
            capital.classList.add("invalid");
        }

        // Validate numbers
        var numbers = /[0-9]/g;
        if (myInput.value.match(numbers)) {
            number.classList.remove("invalid");
            number.classList.add("valid");
        } else {
            number.classList.remove("valid");
            number.classList.add("invalid");
        }

        // Validate length
        if (myInput.value.length >= 8) {
            length.classList.remove("invalid");
            length.classList.add("valid");
        } else {
            length.classList.remove("valid");
            length.classList.add("invalid");
        }
    }

    //VALIDA MODAL DE CRIAÇÃO E ATUALIZAÇÃO DE USUÁRIO
    $("#form-modal-resgitration").validate({

        onkeyup: function (element) {
            this.element(element);
        },
        onfocusout: function (element) {
            this.element(element);
        },
        rules: {
            Username: {
                required: true,
                minlength: 5,
                maxlength: 20
            },
            UserEmail: {
                required: true,
                email: true,
                minlength: 10
            },
            
            ConfirmPassword: {
                required: true,
                equalTo: "#Password"
            },
            mensagem: {
                rangelength: [50, 1050],
            }
        },
        messages: {
            Usename: {
                required: "Este campo deve ser preenchido.",
                minlength: "Digite no mínimo 5 caracteres.",
                maxlength: "Digite no maxímo 30 caracteres."

            },
            UserEmail: {
                required: "Este campo deve ser preenchido.",
                minlength: "Digite no mínimo 5 caracteres.",
                email: "Digite um email válido."
            },
            
            ConfirmPassword: {
                required: "Este campo deve ser preenchido.",
                equalTo: "A senha deve ser igual a anterior."
            },
            mensagem: {
                required: "D",
                minlength: "Mínimo de caracteres permitidos 50",
                maxlength: "Maxímo de caracteres permitidos 1050"
            },
        }
    });
});