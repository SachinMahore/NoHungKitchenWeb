function chooseFile(menuCat) {
    $("#fileInput" + menuCat).click();
}

$(document).ready(function () {

    //alert("Category added Sucessfully");
    getMenuList(1);
    getMenuList(2);
    getMenuList(3);
    getMenuList(4);
    getMenuList(5);
    getMenuList(6);
});
var savemenu = function (menuCat) {
    var message = "";
    $formData = new FormData();
    var kitchenid = $("#lblKitchenId").val();
    var menutitle = $("#txtMenuTitle" + menuCat).val();
    var category = menuCat;
    var qty = $("#txtQty" + menuCat).val();
    var saleprice = $("#txtSalePrice" + menuCat).val();
    var status = "1";
    var description = $("#txtMenuTitle" + menuCat).val();
    var menuphoto = document.getElementById("fileInput" + menuCat);
    
    if (menuphoto.files.length > 0) {
        for (var i = 0; i < menuphoto.files.length; i++) {
            $formData.append('file-' + i, menuphoto.files[i]);
        }
    }
    $formData.append('KitchenId', kitchenid);
    $formData.append('MenuTitle', menutitle);
    $formData.append('Category', category);
    $formData.append('Qty', qty);
    $formData.append('SalePrice', saleprice);
    $formData.append('Status', status);
    $formData.append('Description', description);
    $formData.append('MenuPhoto', menuphoto);

    if (menutitle == "") {
        message += "Please Enter Menu Title";
    } else if (saleprice == "") {
        message += "Please Enter Price";
    } else if (qty == "") {
        message += "Please Enter Qty";
    }
    if (message == "") {
        $.ajax({
            url: '/Menu/SaveMenu',
            method: 'post',
            data: $formData,
            contentType: false,
            dataType: 'json',
            processData: false,
            success: function (response) {
                //$.alert({
                //    title: 'Alert!',
                //    content: "Menu Added Successfully..!",
                //    type: 'blue'
                //});
                getMenuList(menuCat);
            }

        });
    } else {
        $.alert({
            title: 'Alert!',
            content: message,
            type: 'red'
        });
    }
}
var getMenuList = function (menuCat) {
    var kitchenid = $("#lblKitchenId").val();
    var model = { KitchenId: kitchenid, Category: menuCat };
    $.ajax({
        url: "/Menu/GetMenuList",
        method: 'post',
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        datatype: "json",
        async: false,
        success: function (response) {
            console.log(response)
            var html = "";

            $("#tblBMenu" + menuCat+" tbody").empty();
            $.each(response.model, function (index, elementValue) {
                // html += "<tr><td>" + elementValue.MenuId + " </td><td>" + elementValue.KitchenId + "</td><td>" + elementValue.MenuTitle + "</td><td>" + elementValue.Category + "</td><td>" + elementValue.PurchasePrice + "</td><td>" + elementValue.SalePrice + " </td><td>" + elementValue.Discount + " </td><td>" + elementValue.Description + " </td><td>" + elementValue.MenuPhoto + "</td><td><input type='submit' value='Delete' onClick='deleteMenu(" + elementValue.MenuId + ")'/></td></tr>";
                html += "<tr><td><img src='Content/Images/MenuPhoto/" + elementValue.MenuPhoto + "' width='50' height='45'/></td><td><p>" + elementValue.MenuTitle + "</p></td><td><p>₹" + elementValue.SalePrice + "</p></td><td><p>" + elementValue.Qty + "</p></td><td>  <a href='javascript: void (0);' class='InStockButton'>In Stock</a><td><a href='javascript:void (0);' ' onclick='deleteMenu(" + elementValue.MenuId + "," + elementValue.Category + ")'><img class='btn-sm btn-default' src='assets/images/trash.svg'></a></td></tr>";

            });
            $("#tblBMenu" + menuCat +" tbody").append(html);
        }
    });
}
var deleteMenu = function (Menuid,MenuCat) {
    var model = { Id: Menuid };
    $.confirm({
        title: 'Alert!',
        content: 'Are you sure you want to delete the Menu?',
        type: 'red',
        buttons: {
            confirm: function () {
    $.ajax({
        url: "/Menu/DeleteMenu",
        method: 'post',
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: 'json',
        async: false,
        success: function (response) {
            $.alert({
                title: 'Alert!',
                content: "Record Deleted Successfully..!",
                type: 'red'
            });
            getMenuList(MenuCat);
        }
    });
            },
            cancel: function () {
                $("#divLoader").hide();
            }
        }
    });
}
