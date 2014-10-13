﻿var GlobalCartId = "";

$(document).ready(function () {
  CookieChecker();
  GlobalCartId = $.cookie("CartGuidValue");
  var totalItems = 0;

  // Adds the cartItem to cookie...And sets the Menu item for Cart
  AddCookieToMenu();

  // When we download the files, remove cookie, call server controller to remove db cart items, and Zip file.
  $(".download").click(function () {
    $.getJSON("/Admin/RemoveCart", { cartId: GlobalCartId },
        function (data) {
          if (data.returnValue == "error") {
            $.jGrowl("An error has occured!\n" + data.errorMessage);
          }
          else {
            $.removeCookie("CartGuidValue", { expires: 7, path: '/' });
            $('.item').remove();

            $.jGrowl("Cart has been emptied...");
            RemoveCookieFromMenu();
          }
        });


  })

  $(".viewer").click(function () {
    var contentType = $(this).data("contenttype");
    var file = $(this).data("file");
    var title = $(this).data("title");
    switch (contentType) {
      case "PDF File":
        OpenPdf(file, title);
        break;
      case "Image":
        OpenImage(file, title);
        break;
    }
  });

  // Add Item
  $(".cartItem").click(function () {
    var itemId = $(this).data("itemId");
    var itemName = $(this).data("itemName");
    $.getJSON("/Admin/AddToCart", { itemId: itemId, cartId: GlobalCartId },
        function (data) {
          GlobalCartId = data.CartGuid;
          if (data.warning != "")
            $.jGrowl(data.warning, { position: 'bottom-right' });
          else
            $.jGrowl(itemName + " Added!", { position: 'bottom-right' });
          if ($.cookie("CartGuidValue") == "") {
            $.cookie("CartGuidValue", data.CartGuid, { expires: 7, path: '/' });
          }
          AddCookieToMenu();
        });
  });
  // Remove Item
  $(".cartItemRemove").click(function () {
    var itemId = $(this).data("itemId");
    var itemName = $(this).data("itemName");
    var item = $(this);
    bootbox.dialog({
      message: "Are you sure you want to delete " + itemName + "?",
      title: "Delete " + itemName,
      buttons: {
        success: {
          label: "Delete!",
          className: "btn-success",
          callback: function () {
            $.getJSON("/Admin/RemoveFromCart", { itemId: itemId, cartId: GlobalCartId },
                function (data) {
                  if (data.errorMessage != "") {
                    $.jGrowl(data.errorMessage, { position: 'bottom-right' });
                  }
                  else {
                    $.jGrowl(itemName + " Removed!", { position: 'bottom-right' });
                    var parent = item.parent();
                    parent.fadeOut(500, function () { $(this).remove(); });
                  }
                });
          }
        },
        cancel: {
          label: "Cancel",
          className: "btn-danger",
          callback: function () {
            
          }
        }
      }
    });
  });
});

var CookieChecker = function () {
  if ($.cookie("CartGuidValue") == undefined || $.cookie("CartGuidValue") == null || $.cookie("CartGuidValue") == "") {
    $.cookie("CartGuidValue", "", { expires: 7, path: '/' });
  }
}
var AddCookieToMenu = function () {
  if ($.cookie("CartGuidValue") == "undefined" || $.cookie("CartGuidValue") == null || $.cookie("CartGuidValue") == "") {
  }
  else {
    if ($(".myResourcesLink").attr("href").indexOf("cartId") == -1) {
      var newURL = $(".myResourcesLink").attr("href") + "?cartId=" + $.cookie("CartGuidValue");
      $(".myResourcesLink").attr("href", newURL);
    }
  }
}
var RemoveCookieFromMenu = function () {
  if ($(".myResourcesLink").attr("href").indexOf("cartId") == -1) {
    var newURL = $(".myResourcesLink").attr("href").split('?')[0];
    $(".myResourcesLink").attr("href", newURL);
  }
}


var OpenPdf = function (file, title) {
  //var htmlString = "<iframe src=\"http://docs.google.com/gview?url={{myPDFFile}}&embedded=true\" style=\"width:600px; height:500px;\" frameborder=\"0\"></iframe>";
  $("#myModalLabel").text(title);
  var host = location.host;
  //var htmlString = "<iframe src=\""+host+"{{myPDFFile}}\" style=\"width:890px; height:658px;\" frameborder=\"0\"></iframe>";
  var htmlString = "<iframe src=\"{{myPDFFile}}\" style=\"width:1070px; height:658px;\" frameborder=\"0\"></iframe>";
  htmlString = htmlString.replace("{{myPDFFile}}", "/Files/" + file);
  $(".modal-body").html(htmlString);
}
var OpenImage = function (file, title) {
  $("#myModalLabel").text(title);
  var imageSource = "<img src=\"/Files/" + file + "\">"
  $(".modal-body").html(imageSource);
}

var DeleteDialog = function (title, message) {
  bootbox.dialog({
    message: message,
    title: title,
    buttons: {
      success: {
        label: "Delete!",
        className: "btn-success",
        callback: function () {
          return true;
        }
      },
      cancel: {
        label: "Cancel",
        className: "btn-danger",
        callback: function () {
          return false;
        }
      }
    }
  });
}