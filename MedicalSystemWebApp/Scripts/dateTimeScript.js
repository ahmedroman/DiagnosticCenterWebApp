/// <reference path="dateTimeScript.js" />

    var fromDate = "#fromDateTextBox";
    var toDate = "#toDateTextBox";
    $(document).ready(function () {
        dateTimePicker(fromDate);
        dateTimePicker(toDate);

    });
    function dateTimePicker(id) {
        $(id).datepicker({
            yearRange: "-100:+0",
            dateFormat: "mm/dd/yy",
            changeMonth: true,
            changeYear: true
        });
    }
    
