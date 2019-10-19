(
    function (publicMethod, $) {
        publicMethod.showAjaxErrorMessagePopUp = function (xMLHttpRequest, textStatus, errorThrown) {
        }

        publicMethod.claimsItemAddedSuccessfully = function () {
            const Toast = Swal.mixin({
                toast: true,
                position: 'top-end',
                showConfirmButton: false,
                timer: 3000
            })

            Toast.fire({
                type: 'success',
                title: 'Claims item added successfully'
            })
        }
    }(window.claimsAController = window.claimsAController || {}, jQuery)
);