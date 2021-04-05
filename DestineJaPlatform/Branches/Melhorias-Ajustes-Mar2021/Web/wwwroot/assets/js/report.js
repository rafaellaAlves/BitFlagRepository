;

function openListPrint(datatable, charts, title) {
    var form = $('<form>', { target: "_blank", method: "post", action: '/Report/Print' });
    form.append($('<input>', { type: 'hidden', value: title, name: 'Title' }));

    setListPrintValuesIntoForm(form, datatable, charts);

    console.log($(form).serializeArray());

    $('body').append(form);

    form.submit();
    form.remove();
}

function downloadListPrint(datatable, charts, title) {
    var form = $('<form>', { target: "_blank", method: "post", action: '/Report/Download' });
    form.append($('<input>', { type: 'hidden', value: title, name: 'Title' }));

    setListPrintValuesIntoForm(form, datatable, charts);

    $('body').append(form);

    form.submit();
    form.remove();
}

function setFilterIntoForm(form) {
    $.each($('.filter-input'), function (i, e) {
        form.append($('<input>', { type: 'hidden', value: i, name: 'Filters.Index' }));
        form.append($('<input>', { type: 'hidden', value: $(e).data('filter-name'), name: 'Filters[' + i + '].FilterName' }));

        var filterVal = (isNullOrWhiteSpace($(e).val()) ? "" : $(e).val());

        if ($(e).is('select') && !isNullOrWhiteSpace($(e).find('option:selected').data('name'))) {
            if ($(e).attr('multiple')) {
                var values = [];
                $.each($(e).val(), function (j, optionValue) {
                    values.push($(e).find('option[value="' + optionValue + '"]').data('name'));
                });

                filterVal = values.join(', ');

            } else {
                filterVal = $(e).find('option:selected').data('name');
            }
        }

        form.append($('<input>', { type: 'hidden', value: filterVal, name: 'Filters[' + i + '].Value' }));
    });
}

function setTableHeaderIntoForm(form, datatable) {
    if (datatable != null) {
        datatable.columns().header().each(function (e, i) {
            form.append($('<input>', { type: 'hidden', value: i, name: 'TableHeader.Index' }));
            form.append($('<input>', { type: 'hidden', value: (isNullOrWhiteSpace($(e).html()) ? "" : $(e).html()), name: 'TableHeader[' + i + ']' }));
        });
    }
}

function setChartIntoForm(form, charts) {
    if (charts != null) {
        $.each(charts, function (i, e) {
            form.append($('<input>', { type: 'hidden', value: i, name: 'ChartsBase64.Index' }));
            form.append($('<input>', { type: 'hidden', value: 'data:image/svg+xml;base64,' + btoa(encodeURIComponent(e.getSVG()).replace(/%([0-9A-F]{2})/g, function toSolidBytes(match, p1) { return String.fromCharCode('0x' + p1); })), name: 'ChartsBase64[' + i + ']' }));
        });
    }
}

function setListPrintValuesIntoForm(form, datatable, charts) {
    setFilterIntoForm(form);

    if (datatable != null) {
        datatable.rows({ filter: 'applied' }).data().each(function (e, i) {
            form.append($('<input>', { type: 'hidden', value: i, name: 'TableData.Index' }));

            $.each(e, function (j, _e) {
                form.append($('<input>', { type: 'hidden', value: j, name: 'TableData[' + i + '].Index' }));
                form.append($('<input>', { type: 'hidden', value: _e, name: 'TableData[' + i + '][' + j + ']' }));
            });
        });

        setTableHeaderIntoForm(form, datatable);
    }

    setChartIntoForm(form, charts);
}