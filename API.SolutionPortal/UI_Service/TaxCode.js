const GetTaxCode = () => {
    $.ajax({
        type: "GET",
        url: "api/TaxCode/GetList",
        contentType: "application/json; charset=utf-8",
        crossDomain: true,
        //dataType: "json",
        success: function (data, status, jqXHR) {

            if (data.StatusCode === 200) {
                tmpMenuList = data.Data;
                var companyStr = "";
                if (data.Data.length > 0) {
                    data.Data.map((item) => {
                        companyStr += "<tr>";
                        companyStr += '<td><button class="btnClickTaxCode btn btn-info" id="btn_' + item.Id + '">Detay</button><button class="btnDeleteTaxCode btn btn-danger" style="margin-left:10px" id="btn_' + item.Id + '">Sil</button></td>';
                        companyStr += '<td>' + item.Indicator + '</td>';
                        companyStr += '<td>' + item.Defination + '</td>';
                        companyStr += '<td>' + item.Rate + '</td>';
                        companyStr += " </tr>";
                    });
                }
                else {
                    companyStr += "<tr>";
                    companyStr += '<td>Vergi Kodu bulunamadı.</td>';
                    companyStr += " </tr>";
                }

                $("#tBodyTaxCode").html(companyStr);
            }
        },

        error: function (jqXHR, status) {
            // error handler
            console.log(jqXHR);
            alert('fail' + status.code);
        }
    });
}

$(function () {
    GetTaxCode();

    $(document).on('click', '.btnDeleteTaxCode', function () {
        var id = $(this).attr("id");
        var splitId = id.split("_")[1];
        var dto = {
            Id: splitId
        };
        $.ajax({
            type: "POST",
            url: "api/TaxCode/Delete",
            data: JSON.stringify(dto),// now data come in this function
            contentType: "application/json; charset=utf-8",
            crossDomain: true,
            dataType: "json",
            success: function (data, status, jqXHR) {
                if (data.StatusCode === 200) {
                    GetTaxCode();
                }
                else {
                    alert(data.Message);
                }
            },

            error: function (jqXHR, status) {
                // error handler
                alert('fail' + status.code);
            }
        });

    });


    $(document).on('click', '.btnClickTaxCode', function () {
        $("#txtTaxCodeIndicator").val("");
        $("#txtTaxCodeDescription").val("");
        $("#txtTaxCodeRate").val("");
        var id = $(this).attr("id");
        var splitId = id.split("_")[1];
        var dto = {
            Id: splitId
        };
        $.ajax({
            type: "POST",
            url: "api/TaxCode/Get",
            data: JSON.stringify(dto),// now data come in this function
            contentType: "application/json; charset=utf-8",
            crossDomain: true,
            dataType: "json",
            success: function (data, status, jqXHR) {
                console.log(data);
                if (data.StatusCode === 200) {
                    $("#txtTaxCodeIndicator").val(data.Data.Indicator);
                    $("#txtTaxCodeDescription").val(data.Data.Defination);
                    $("#txtTaxCodeRate").val(data.Data.Rate);

                    $("#hdTaxCodeClickType").val("2");
                    $("#hdTaxCodeId").val(splitId);
                }
            },

            error: function (jqXHR, status) {
                // error handler
                alert('fail' + status.code);
            }
        });

    });

    $(document).on('click', '#btnTaxCodeSave', function () {
        var hdCompanyClickType = $("#hdTaxCodeClickType").val();
        var hdCompanyId = $("#hdTaxCodeId").val();
        var txtTaxCodeIndicator = $("#txtTaxCodeIndicator").val();
        var txtTaxCodeDescription = $("#txtTaxCodeDescription").val();
        var txtTaxCodeRate = $("#txtTaxCodeRate").val();
        var isAddOrUpdate = false;
        try {
            if (hdCompanyClickType === "2") {
                isAddOrUpdate = true;
            }
            else {
                hdCompanyId = 0;
            }
        } catch (e) {
            hdCompanyId = 0;
        }

        var dto = {
            Id: hdCompanyId,
            Indicator: txtTaxCodeIndicator,
            Defination: txtTaxCodeDescription,
            Rate: txtTaxCodeRate
        };
        $("#btnTaxCodeSave").prop("disabled", true);
        $.ajax({
            type: "POST",
            url: "api/TaxCode/Add",
            data: JSON.stringify(dto),// now data come in this function
            contentType: "application/json; charset=utf-8",
            crossDomain: true,
            dataType: "json",
            success: function (data, status, jqXHR) {
                console.log(data);
                if (data.StatusCode === 200) {
                    GetTaxCode();
                    if (isAddOrUpdate) {
                        $("#hdTaxCodeClickType").val("");
                        $("#hdTaxCodeId").val("");
                    }
                }

                $("#txtTaxCodeIndicator").val("");
                $("#txtTaxCodeDescription").val("");
                $("#txtTaxCodeRate").val("");

                $("#btnTaxCodeSave").prop("disabled", false);
            },

            error: function (jqXHR, status) {
                // error handler
                alert('fail' + status.code);
                $("#btnTaxCodeSave").prop("disabled", false);
            }
        });

    });
});



