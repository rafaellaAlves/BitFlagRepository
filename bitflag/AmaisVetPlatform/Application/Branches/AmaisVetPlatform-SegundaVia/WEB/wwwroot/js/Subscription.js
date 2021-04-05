function validateSubscription(o, callback) {
    $.ajax({
        type: "POST",
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        url: '@Url.Action("Validate", "Subscription")',
        data: JSON.stringify(o),
        success: callback,
    })
        .done(function (name, price) {
            $('input[name="PlanNameClient"]').val("Plano Básico"),
                $('input[name="PriceClient"]').val("R$ 29,37");
        });
}


$(document).ready(function () {



    //VALIDA SUBSCRIPTION RETORNA E HABILITA UPGRADE
    $("button#valid").click(function () {
        $('#not-found').hide();
        $('#hiddenPlanClient').hide();
        $('#hiddenPlans2').hide();
        validateSubscription({
            "FullName": "",
            "Reference": $('input[name="Reference"]').val()
        }, function (d) {

            if (d) {
                $('#hiddenPlanClient').show(),
                    $('#hiddenPlans2').show();

            } else {
                $('#not-found').show();
            }
        });

    });


});