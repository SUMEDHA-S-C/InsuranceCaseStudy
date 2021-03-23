function calculatePremium() {

    //variables
    var plan = document.getElementById("planNumber").value;
    var mode = document.getElementById("mode").value;
    var sum = document.getElementById("sum").value;
    var term = document.getElementById("term").value;
    var date = document.getElementById("date");
    var today = new Date();

    term = parseInt(term);
    var premiumMode = 0;
    var premiumAmount = 0.0;

    if (mode == "Monthly") {
        premiumMode = 1;
        var month = today.getMonth() + 2;
        date.value = today.getDate() + "/" + month + "/" + today.getFullYear();
    }


    else if (mode == "Yearly") {
        premiumMode = 12;
        var year = today.getFullYear() + 1;
        date.value = today.getDate() + "/" + (+today.getMonth() + +1) + "/" + year;
    }


    else if (mode == "Quaterly") {
        premiumMode = 3;
        var month = today.getMonth() + 4;
        date.value = today.getDate() + "/" + month + "/" + today.getFullYear();
    }

    else if (mode == "HalfYearly") {
        premiumMode = 6;
        //console.log(premiumMode);
        var month = today.getMonth() + 7;
        date.value = today.getDate() + "/" + month + "/" + today.getFullYear();
    }
       

    if (plan == 1) {
        var total = (sum / (term * 12)) * premiumMode;
        var bonus = total * 0.03;
        premiumAmount = total - bonus;
    }

    else if (plan == 2) {
        premiumAmount = (sum / (term * 12)) * premiumMode;
    }

    document.getElementById("premium").value = premiumAmount;
}