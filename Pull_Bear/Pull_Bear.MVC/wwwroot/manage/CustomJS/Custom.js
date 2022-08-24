$(document).ready(function () {

    //----------------------------------------------- Category toggle class when it is main or child

    $(document).on('change', '.isMaininput', function () {
        if ($(this).is(":checked")) {
            $('.parentcontainer').addClass('d-none');
        } else {
            $('.parentcontainer').removeClass('d-none');
        }
    })
});