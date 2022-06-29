const GetMatchingMaster = () => {
    $.ajax({
        type: "GET",
        url: "api/MatchingMasterAccount/GetList",
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
                        companyStr += '<td><button class="btnClickMatching btn btn-info" id="btn_' + item.Id + '">Detay</button><button class="btnDeleteMatching btn btn-danger" style="margin-left:10px" id="btn_' + item.Id + '">Sil</button></td>';
                        companyStr += '<td>' + item.Company.CompanyCode + ' - ' + item.Company.CompanyDefination + '</td>';
                        companyStr += '<td>' + item.FirstCostCenter.CostCenterCode + ' - ' + item.FirstCostCenter.CostCenterDefination + '</td>';
                        companyStr += '<td>' + item.LastCostCenter.CostCenterCode + ' - ' + item.LastCostCenter.CostCenterDefination + '</td>';
                        companyStr += '<td>' + item.MasterAccount + '</td>';
                        companyStr += " </tr>";
                    });


                }
                else {
                    companyStr += "<tr>";
                    companyStr += '<td>Eşleştirme bulunamadı.</td>';
                    companyStr += " </tr>";
                }

                $("#tBodyMatching").html(companyStr);
            }
        },

        error: function (jqXHR, status) {
            // error handler
            alert('fail' + status.code);
        }
    });
}

const getCostCenterByCompanyId1 = (id) => {
    var dto = {
        CompanyId: id
    };
    $.ajax({
        type: "POST",
        url: "api/CostCenter/GetCostCenterByCompanyId",
        data: JSON.stringify(dto),// now data come in this function
        contentType: "application/json; charset=utf-8",
        crossDomain: true,
        dataType: "json",
        success: function (data, status, jqXHR) {

            if (data.StatusCode === 200) {
                tmpMenuList = data.Data;
                var companyStr = '<option value=""></option>';
                if (data.Data.length > 0) {
                    data.Data.map((item) => {
                        companyStr += '<option value=' + item.Id + '>' + item.CostCenterCode + ' - ' + item.CostCenterDefination + '</option>';
                    });
                }

                $("#dropFirstCostCenter").html(companyStr);
                $("#dropLastCostCenter").html(companyStr);
            }
        },

        error: function (jqXHR, status) {
        }
    });

};
const GetPersonCompany = () => {
    $.ajax({
        type: "GET",
        url: "api/Company/GetList",
        contentType: "application/json; charset=utf-8",
        crossDomain: true,
        //dataType: "json",
        success: function (data, status, jqXHR) {

            if (data.StatusCode === 200) {
                tmpMenuList = data.Data;
                var companyStr = '<option value=""></option>';
                if (data.Data.length > 0) {
                    data.Data.map((item) => {
                        companyStr += '<option value=' + item.Id + '>' + item.CompanyCode + ' - ' + item.CompanyDefination + '</option>';
                    });
                }

                $("#dropPersonCompany").html(companyStr);
            }
        },

        error: function (jqXHR, status) {
            // error handler
            alert('fail' + status.code);
        }
    });
}


$(function () {
    GetMatchingMaster();
    GetPersonCompany();

    $(document).on('click', '.btnDeleteMatching', function () {
        var id = $(this).attr("id");
        var splitId = id.split("_")[1];
        var dto = {
            Id: splitId
        };
        $.ajax({
            type: "POST",
            url: "api/MatchingMasterAccount/Delete",
            data: JSON.stringify(dto),// now data come in this function
            contentType: "application/json; charset=utf-8",
            crossDomain: true,
            dataType: "json",
            success: function (data, status, jqXHR) {
                if (data.StatusCode === 200) {
                    $("#dropPersonCompany").val("");
                    $("#dropFirstCostCenter").val("");
                    $("#dropLastCostCenter").val("");
                    $("#txtMasterAccount").val("");
                    GetMatchingMaster();
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


    $(document).on('click', '.btnClickMatching', function () {
        $("#dropPersonCompany").val("");
        $("#dropFirstCostCenter").val("");
        $("#dropLastCostCenter").val("");
        $("#txtMasterAccount").val("");
        var id = $(this).attr("id");
        var splitId = id.split("_")[1];
        var dto = {
            Id: splitId
        };
        $.ajax({
            type: "POST",
            url: "api/MatchingMasterAccount/Get",
            data: JSON.stringify(dto),// now data come in this function
            contentType: "application/json; charset=utf-8",
            crossDomain: true,
            dataType: "json",
            success: function (data, status, jqXHR) {
                if (data.StatusCode === 200) {
                    $("#dropPersonCompany").val(data.Data.CompanyId);
                   // getCostCenterByCompanyId1(data.Data.CompanyId);
                    var dto1 = {
                        CompanyId: data.Data.CompanyId
                    };
                    $.ajax({
                        type: "POST",
                        url: "api/CostCenter/GetCostCenterByCompanyId",
                        data: JSON.stringify(dto1),// now data come in this function
                        contentType: "application/json; charset=utf-8",
                        crossDomain: true,
                        dataType: "json",
                        success: function (data1, status, jqXHR) {

                            if (data1.StatusCode === 200) {
                                tmpMenuList = data1.Data;
                                var companyStr = '<option value=""></option>';
                                if (data1.Data.length > 0) {
                                    data1.Data.map((item) => {
                                        companyStr += '<option value=' + item.Id + '>' + item.CostCenterCode + ' - ' + item.CostCenterDefination + '</option>';
                                    });
                                }

                                $("#dropFirstCostCenter").html(companyStr);
                                $("#dropLastCostCenter").html(companyStr);

                                $("#dropFirstCostCenter").val(data.Data.FirstCostCenterId);
                                $("#dropLastCostCenter").val(data.Data.LastCostCenterId);
                            }
                        },

                        error: function (jqXHR, status) {
                        }
                    });
                    $("#dropFirstCostCenter").val(data.Data.FirstCostCenterId);
                    $("#txtMasterAccount").val(data.Data.MasterAccount);
                    $("#hdMatchingClickType").val("2");
                    $("#hdMatchingId").val(splitId);
                }
            },

            error: function (jqXHR, status) {
                // error handler
                alert('fail' + status.code);
            }
        });

    });

    $("#dropPersonCompany").change(function () {
        $("#dropFirstCostCenter").html("");
        $("#dropLastCostCenter").html("");
        var companyId = this.value;
        getCostCenterByCompanyId1(companyId);
    });

    $(document).on('click', '#btnMatchingSave', function () {
        var hdCompanyClickType = $("#hdMatchingClickType").val();
        var hdCompanyId = $("#hdMatchingId").val();

        var dropPersonCompany = $("#dropPersonCompany").val();
        var dropFirstCostCenter = $("#dropFirstCostCenter").val();
        var dropLastCostCenter = $("#dropLastCostCenter").val();
        var txtMasterAccount = $("#txtMasterAccount").val();

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
            FirstCostCenterId: dropFirstCostCenter,
            LastCostCenterId: dropLastCostCenter,
            MasterAccount: txtMasterAccount,
            CompanyId: dropPersonCompany
        };
        $("#btnMatchingSave").prop("disabled", true);
        $.ajax({
            type: "POST",
            url: "api/MatchingMasterAccount/Add",
            data: JSON.stringify(dto),// now data come in this function
            contentType: "application/json; charset=utf-8",
            crossDomain: true,
            dataType: "json",
            success: function (data, status, jqXHR) {
                if (data.StatusCode === 200) {
                    $("#dropFirstCostCenter").html("");
                    $("#dropLastCostCenter").html("");
                    GetMatchingMaster();
                    if (isAddOrUpdate) {
                        $("#hdMatchingClickType").val("");
                        $("#hdMatchingId").val("");
                    }
                }

                $("#dropPersonCompany").val("");
                $("#dropFirstCostCenter").val("");
                $("#dropLastCostCenter").val("");
                $("#txtMasterAccount").val("");

                $("#btnMatchingSave").prop("disabled", false);
            },

            error: function (jqXHR, status) {
                // error handler
                alert('fail' + status.code);
                $("#btnMatchingSave").prop("disabled", false);
            }
        });

    });
});



