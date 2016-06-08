var addedTest = [];
var sl = 1;
var totalFee = 0;
$(document).ready(function () {
    $("#addedTestDiv").hide();
    dateTimePicker();
    hiddenFieldToTest();
    loadFee();
    addTestToTable(); 
    loadAddedTestToHiddenField();
});

function dateTimePicker() {
    $("#DOBTextBox").datepicker({
        yearRange: "-100:+0",
        dateFormat: "mm/dd/yy",
        changeMonth: true,
        changeYear: true
    });
}
function loadAddedTestToHiddenField() {
   
    $("#saveTestsButton").click(function () {
        var addedTestString = "";
        for (var i = 0; i < addedTest.length; i++) {
            addedTestString += addedTest[i].TestToString() + ",";
        }
        $("#addedTestHiddenField").val(addedTestString);
        $("#totalFeeHiddenField").val(totalFee);
    });
    
}
function addTestToTable() {
    $("#addTestButton").click(function () {
        $("#messageLabel").text("");
        validationFuncion();
        if ($("#messageLabel").text() !== "")
        {
            return;
        }
        
        if ($("#testDropDownList option:selected").index() == 0) {
            alert("Please select a Test");
            return;
        }
        var testId = $("#testDropDownList option:selected").val();
        for (var i = 0; i < addedTest.length; i++) {
            if (addedTest[i].Id === testId) {
                alert("Test alreay been added.");
                return;
            }
        }
        $("#addedTestDiv").show();
        var test = getTestById(testId);
        //add selected test to array
        addedTest.push(test);
        $("#testTable").append("<tr><td>" + sl + "</td><td>" + test.Name + "</td><td>" + test.Fee + "</td></tr>");
        sl++;
        totalFee = +totalFee + +test.Fee;
        $("#totalFeeLabel").text(totalFee);
    });

}
function validationFuncion()
{
    if($("#patientNameTextBox").val() === ""){
        $("#messageLabel").text("Name can't be empty.");
        return;
    }
    else if ($("#DOBTextBox").val() === "") {
        $("#messageLabel").text("Date of birth can't be empty.");
        return;
    }
    else if ($("#patientMobileTextBox").val() === "") {
        $("#messageLabel").text("Mobile can't be empty.");
        return;
    }
}
function loadFee() {
    $("#testDropDownList").change(function () {
        $("#feeLabel").text("");
        var selectedTestId = $("#testDropDownList option:selected").val();
        if ($("#testDropDownList option:selected").index() != 0) {
            $("#feeLabel").text(getTestById(selectedTestId).Fee);
        }
    });
}
function hiddenFieldToTest()
{
    var allTestString = $("#allTestHiddenField").val();
    var allTestArry = allTestString.split(",");
    for (var i = 0; i < allTestArry.length - 1; i++) {
        var testArray = allTestArry[i].split("|");
        var test = new Test(testArray[0], testArray[1], testArray[2]);
        allTestArry[i] = test;
    }
    return allTestArry;
}
function getTestById(testId) {
    var allTest = hiddenFieldToTest();
    for (var i = 0; i < allTest.length; i++){
        if (allTest[i].Id === testId) {
            return allTest[i];
        }
    }
}
var Test = function (id, name, fee) {
    this.Id = id;
    this.Name = name;
    this.Fee = fee;
    this.TestToString = function () {
        return this.Id + "|" + this.Name + "|" + this.Fee;
    }
}