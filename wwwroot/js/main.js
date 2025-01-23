var get_id;
function showmassage(id) {
    get_id = id;
  
    $('#del').modal('show');
}

function confirm_delete() {

    window.location.href = "Deletestudium1?id=" + get_id //connect to back_end

}



function confirm_delete1()
{
    window.location.href = "DeleteHotel?id=" + get_id
}


function confirm_delete2() {
    window.location.href = "DeleteCategries?id=" + get_id
}


function confirm_delete3() {
    window.location.href = "DeleteTransport?id=" + get_id
}

function confirm_delete4() {
    window.location.href = "DeleteTableFootbul?id=" + get_id
}

/*function Add_tocart(id) {
    $.ajax({
        url: 'Add_tocart', // إزالة المسافة الزائدة
        type: "POST",
        data: { id: get_id }, // استخدام المتغير id بدلاً من get_id
        success: function (result) {
            const Toast = Swal.mixin({
                toast: true, // تصحيح الخطأ الإملائي
                position: "top-end",
                showConfirmButton: false, // تصحيح الخطأ الإملائي
                timer: 3000,
                timerProgressBar: true,
                didOpen: (toast) => {
                    toast.onmouseenter = Swal.stopTimer;
                    toast.onmouseleave = Swal.resumeTimer; // تصحيح الخطأ الإملائي
                }
            });
            Toast.fire({
                icon: "success",
                title: "تم الإضافة إلى السلة بنجاح"
            });
        }
    })
}*/



function Add_tocart(id) {
    // زيادة العداد في التخزين المحلي
    var counter = localStorage.getItem("counter");
    if (counter) {
        counter = parseInt(counter) + 1;
    } else {
        counter = 1;
    }
    localStorage.setItem("counter", counter);

    // إرسال الطلب باستخدام 
    $.ajax({
        url: 'Add_tocart',
        type: "POST",
        data: { id: id },
        success: function (result) {
            const Toast = Swal.mixin({
                toast: true,
                position: "top-end",
                showConfirmButton: false,
                timer: 3000,
                timerProgressBar: true,
                didOpen: (toast) => {
                    toast.onmouseenter = Swal.stopTimer;
                    toast.onmouseleave = Swal.resumeTimer;
                }
            });
            Toast.fire({
                icon: "success",
                title: "تم الإضافة إلى السلة بنجاح. العدد الحالي: " + counter
            });
        }
    });
}
document.addEventListener("DOMContentLoaded", function () {
    var counter = localStorage.getItem("counter");
    if (counter) {
        document.getElementById("cart").innerText = counter;
    } else {
        document.getElementById("cart").innerText = 0;
    }
});


function Add_TRAN(id) {
    // التحقق من دعم التخزين المحلي
    if (typeof (Storage) !== "undefined") {
        // زيادة العداد في التخزين المحلي
        let counter = localStorage.getItem("counter");
        if (counter) {
            counter = parseInt(counter) + 1;
        } else {
            counter = 1;
        }
        localStorage.setItem("counter", counter);

        // إرسال الطلب باستخدام AJAX
        $.ajax({
            url: 'Add_TRAN',
            type: "POST",
            data: { id: id },
            success: function (result) {
                const Toast = Swal.mixin({
                    toast: true,
                    position: "top-end",
                    showConfirmButton: false,
                    timer: 3000,
                    timerProgressBar: true,
                    didOpen: (toast) => {
                        toast.onmouseenter = Swal.stopTimer;
                        toast.onmouseleave = Swal.resumeTimer;
                    }
                });
                Toast.fire({
                    icon: "success",
                    title: "تم الإضافة إلى السلة بنجاح. العدد الحالي: " + counter
                });
            },
            error: function (xhr, status, error) {
                console.error("حدث خطأ: " + error);
            }
        });
    } else {
        console.error("التخزين المحلي غير مدعوم في هذا المتصفح.");
    }
}

document.addEventListener("DOMContentLoaded", function () {
    const counter = localStorage.getItem("counter");
    if (counter) {
        document.getElementById("cart").innerText = counter;
    } else {
        document.getElementById("cart").innerText = 0;
    }
});


//TEST MAP




