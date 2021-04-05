function actionBody() {
    var op = document.getElementById("actions").value;
    if (op == 1) {
        window.location.href = "https://localhost:44399/Home/Index";//pagina admin
    }
    if (op == 2) {
        window.location.href = "https://localhost:44399/Home/Index";//pagina home
    }
}

//FUNÇÃO PARA HABILITAR PAGAMENTO
function option() {
    var op = document.getElementById("Collection").value;
    if (op == 1) {
        $('#hiddenRow').hide(),
            $('#hiddenCard').show();
    }
    if (op == 2) {
        $('#hiddenRow').show(),
            $('#hiddenCard').hide();
    }
}

//FUNÇÃO PARA ESCOLHA DE FORMA DE PAGAMENTO
function optionPay() {
    var option = document.getElementById("Options").value;
    if (option == 1) {
        $('#hiddenCredit').show(),
            $('#hiddenPayment').hide(),
            $('#hiddenCredit2').show();
    }
    if (option == 2) {
        $('#hiddenCredit').hide(),
            $('#hiddenPayment').show(),
            $('#hiddenCredit2').hide();
    }
}