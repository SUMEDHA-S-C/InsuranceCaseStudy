function calculatePremium() {
    var plan = document.getElementById("planNumber").value;
    var mode = document.getElementById("mode").value;
    var sum = document.getElementById("sum").value;
    var term = document.getElementById("term").value;
    term = parseInt(term);
    var premiumMode = 0;
    var premiumAmount = 0.0;

    if (mode == "Monthly")
        premiumMode = 1;

    else if (mode == "Yearly")
        premiumMode = 12;

    else if (mode == "Quaterly")
        premiumMode = 3;

    else if (mode == "Half-Yearly")
        premiumMode = 6;

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