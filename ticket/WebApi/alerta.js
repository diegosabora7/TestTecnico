(function ($) {
    showSwal = function (type) {
        'use strict';
        if (type === 'auto-close') {
            swal({
                title: 'Auto close alert!',
                text: 'I will close in 2 seconds.',
                timer: 2000,
                button: false
            }).then(
                function () { },
                // handling the promise rejection
                function (dismiss) {
                    if (dismiss === 'timer') {
                        console.log('I was closed by the timer')
                    }
                }
            )
        } else {
            swal("Error occured !");
        }
    }

})(jQuery);