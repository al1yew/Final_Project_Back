$(document).ready(function () {

    //----------------------------------------------- Category toggle class when it is main or child

    //if ($('.isMaininput').is(":checked")) {
    //    $('.parentcontainer').addClass('d-none');
    //} else {
    //    $('.parentcontainer').removeClass('d-none');
    //}

    $(document).on('change', '.isMaininput', function () {
        $('.parentcontainer').toggleClass('d-none');
        //if ($(this).is(":checked")) {
        //    $('.parentcontainer').addClass('d-none');
        //} else {
        //    $('.parentcontainer').removeClass('d-none');
        //}
    })
});