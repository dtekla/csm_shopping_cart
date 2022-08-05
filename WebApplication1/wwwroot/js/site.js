$(function () {

    if ($("a.confirmDeletion").length) {
        $("a.confirmDeletion").click(() => {
            if (!confirm("Confirm deletion")) return false;
        });
    }

    if ($("div.alert.notification").length) {
        setTimeout(() => {
            $("div.alert.notification").fadeOut();
        }, 2000)
    }
})

function readURL(input) {
       
        if (input.files && input.files[0]) {

            let reader = new FileReader();
            reader.onload = function (e) {
           
                 $("#imgupload").attr("src", e.target.result).width(200).height(200);

            };

            reader.readAsDataURL(input.files[0]);
         }
}

function addToCart(e, id) {
    e.preventDefault();

    let ajaxDiv = $(e.target).parent().parent().find("div.ajaxbg");

    console.log(ajaxDiv)

    ajaxDiv.removeClass("d-none");

   

    $.get('/cart/add/' + id, {}, function (data) {
        $("div.smallcart").html(data);
        ajaxDiv.find("img").addClass("d-none");
        ajaxDiv.find("p").removeClass("d-none");
        setTimeout(() => {
            ajaxDiv.animate({ opacity: 0 }, function () {
                $/*(e.target).addClass("d-none").fadeTo(.1, 1);*/
                $(e.target).find("img").removeClass("d-none");
                $(e.target).find("p").addClass("d-none");
            })
        })
    });
}


function payPalSubmit(e) {
    e.preventDefault();

    $("div.cartbg").removeClass("d-none");

    $.get("/cart/clear", {}, function () {
        $("form.paypalform").submit();
    })
}
