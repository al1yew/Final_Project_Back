$(document).ready(function () {

    //----------------------------------------------- Category toggle class when it is main or child

    $(document).on('change', '.isMaininput', function () {
        $('.parentcontainer').toggleClass('d-none');
    })
});