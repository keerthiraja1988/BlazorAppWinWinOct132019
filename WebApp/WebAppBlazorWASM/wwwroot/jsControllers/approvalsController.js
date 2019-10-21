(
    function (publicMethod, $) {
        publicMethod.ProcessCreateEmployeeSuccessModalShow = function () {
            $('#ProcessCreateEmployeeSuccessModal').modal('show');
        }

        publicMethod.ProcessCreateEmployeeSuccessModalHide = function () {
            $('#ProcessCreateEmployeeSuccessModal').modal('hide');
        }
    }(window.approvalsController = window.approvalsController || {}, jQuery)
);