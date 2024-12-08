var deleteUrl = "";
var deleteReturnUrl = "";

$(".hoverPicture").mouseover(function () {
    $(".kResim").show();
    $(".kResim").attr("src", $(this).attr("picture"));
    $(".kResim").css("top", $(this).offset().top - 80);
});

function deleteSlideRecord(id) {
    deleteUrl = "/admin/slide/delete?_id=" + id;
    deleteReturnUrl = "/admin/slide/index"
    $("#deleteModal").modal("show");
}

function deleteCategoryRecord(id) {
    deleteUrl = "/admin/category/delete?_id=" + id;
    deleteReturnUrl = "/admin/category/index"
    $("#deleteModal").modal("show");
}


function deleteProductRecord(id) {
    deleteUrl = "/admin/product/delete?_id=" + id;
    deleteReturnUrl = "/admin/product/index"
    $("#deleteModal").modal("show");
}







function deleteRecord() {
    $.ajax({
        type: "GET",
        url: deleteUrl,
        success: function (data) {
            if (data != null) {
                $("#deleteModal").modal("hide");
                setTimeout(function () {
                    location.href = deleteReturnUrl
                }, 500);
            }
            else alert("Hata Oluştu...");
        },
        error: function (error) { alert(error.responseText) }
    });
}




