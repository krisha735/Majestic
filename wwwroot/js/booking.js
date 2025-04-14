let total = 0;
let discount = 0;
let hasItems = false;
let selectedCountry = "";

function updateDisplay() {
    document.getElementById("total-price").innerText = total.toFixed(2);
    document.getElementById("final-price").innerText = (total - discount).toFixed(2);
    document.getElementById("checkout").style.display = hasItems ? "block" : "none";
}

function addItem(name, price) {
    if (!selectedCountry) {
        alert("Please select a destination country before booking.");
        return;
    }

    const li = document.createElement("li");
    li.innerHTML = `${name} - $${price} <button class="remove-btn" onclick="removeItem(this, ${price})">❌</button>`;
    document.getElementById("selected-items").appendChild(li);

    total += price;
    hasItems = true;
    discount = 0;
    document.getElementById("promo").value = "";
    document.getElementById("discount-msg").innerText = "";

    updateDisplay();
    document.getElementById("checkout-country").innerText = selectedCountry;
}

function removeItem(button, price) {
    const li = button.parentElement;
    li.remove();
    total -= price;

    const itemCount = document.querySelectorAll("#selected-items li").length;
    hasItems = itemCount > 0;

    discount = 0;
    document.getElementById("promo").value = "";
    document.getElementById("discount-msg").innerText = "";

    updateDisplay();
}

function applyPromo() {
    const code = document.getElementById("promo").value.trim().toUpperCase();

    if (code === "MAJESTIC10") {
        discount = total * 0.10;
        document.getElementById("discount-msg").innerText = "Promo applied: 10% off!";
        document.getElementById("discount-msg").style.color = "green";
    } else {
        discount = 0;
        document.getElementById("discount-msg").innerText = "Invalid promo code.";
        document.getElementById("discount-msg").style.color = "red";
    }

    updateDisplay();
}

function countrySelected() {
    const select = document.getElementById("country-select");
    selectedCountry = select.value;

    const msg = document.getElementById("selected-country-msg");
    if (selectedCountry) {
        msg.innerText = `Destination selected: ${selectedCountry}`;
    } else {
        msg.innerText = "";
    }

    document.getElementById("checkout-country").innerText = selectedCountry;
}

// Simulate secure payment and show success message
function completePayment() {
    const finalPrice = (total - discount).toFixed(2);

    // Simulate secure payment process
    setTimeout(() => {
        // Show success message on payment completion
        document.getElementById("payment-success-msg").style.display = "block";
        document.getElementById("payment-success-msg").innerHTML = `
            <h3>Payment Successful!</h3>
            <p>Your booking has been confirmed. Thank you for choosing us!</p>
            <p><strong>Final Price:</strong> $${finalPrice}</p>
        `;
        // Hide the checkout section after payment
        document.getElementById("checkout").style.display = "none";
    }, 2000); // Simulate a 2-second payment processing time
}
