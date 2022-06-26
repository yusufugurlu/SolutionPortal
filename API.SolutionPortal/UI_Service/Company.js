const GetCompany=() => {
    $.ajax({
        type: "GET",
        url: "api/Company/GetList",
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
                        companyStr += '<td><button class="btnClickCompany btn btn-info" id="btn_' + item.Id + '">Detay</button><button class="btnDeleteCompany btn btn-danger" style="margin-left:10px" id="btn_' + item.Id + '">Sil</button></td>';
                        companyStr += '<td>' + item.CompanyCode + '</td>';
                        companyStr += '<td>' + item.CompanyDefination + '</td>';
                        companyStr += " </tr>";
                    });
                }
                else {
                    companyStr += "<tr>";
                    companyStr += '<td>Şirket bulunamadı.</td>';
                    companyStr += " </tr>";
                }

                $("#tBodyCompany").html(companyStr);
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
    GetCompany();

    $(document).on('click', '.btnDeleteCompany', function () {
        var id = $(this).attr("id");
        var splitId = id.split("_")[1];
        var dto = {
            Id: splitId
        };
        $.ajax({
            type: "POST",
            url: "api/Company/Delete",
            data: JSON.stringify(dto),// now data come in this function
            contentType: "application/json; charset=utf-8",
            crossDomain: true,
            dataType: "json",
            success: function (data, status, jqXHR) {
                if (data.StatusCode === 200) {
                    GetCompany();
                }
                else {
                    alert(data.Message);
                }
            },

            error: function (jqXHR, status) {
                // error handler
                alert('fail' + status.code);
                $("#btnLogin").prop("disabled", false);
            }
        });

    });


    $(document).on('click', '.btnClickCompany', function () {
        $("#txtCompanyCode").val("");
        $("#txtCompanyDescription").val("");
        var id = $(this).attr("id");
        var splitId = id.split("_")[1];
        var dto = {
            Id:splitId
        };
        $.ajax({
            type: "POST",
            url: "api/Company/Get",
            data: JSON.stringify(dto),// now data come in this function
            contentType: "application/json; charset=utf-8",
            crossDomain: true,
            dataType: "json",
            success: function (data, status, jqXHR) {
                console.log(data);
                if (data.StatusCode === 200) {
                    $("#txtCompanyCode").val(data.Data.CompanyCode);
                    $("#txtCompanyDescription").val(data.Data.CompanyDefination);
                    $("#hdCompanyClickType").val("2");
                    $("#hdCompanyId").val(splitId);
                }
            },

            error: function (jqXHR, status) {
                // error handler
                alert('fail' + status.code);
                $("#btnLogin").prop("disabled", false);
            }
        });

    });

    $(document).on('click', '#btnCompanySave', function () {
        var hdCompanyClickType = $("#hdCompanyClickType").val();
        var hdCompanyId = $("#hdCompanyId").val();
        var txtCompanyCode= $("#txtCompanyCode").val();
        var txtCompanyDescription= $("#txtCompanyDescription").val();
        var isAddOrUpdate = false;
        try {
            if (hdCompanyClickType==="2") {
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
            CompanyCode: txtCompanyCode,
            CompanyDefination: txtCompanyDescription
        };
        $("#btnCompanySave").prop("disabled", true);
        $.ajax({
            type: "POST",
            url: "api/Company/Add",
            data: JSON.stringify(dto),// now data come in this function
            contentType: "application/json; charset=utf-8",
            crossDomain: true,
            dataType: "json",
            success: function (data, status, jqXHR) {
                console.log(data);
                if (data.StatusCode === 200) {
                    GetCompany();
                    if (isAddOrUpdate) {
                       $("#hdCompanyClickType").val("");
                       $("#hdCompanyId").val("");
                    }
                }
                $("#txtCompanyCode").val("");
                $("#txtCompanyDescription").val("");
                $("#btnCompanySave").prop("disabled", false);
            },

            error: function (jqXHR, status) {
                // error handler
                alert('fail' + status.code);
                $("#btnCompanySave").prop("disabled", false);
            }
        });

    });
});



