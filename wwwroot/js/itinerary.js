let totalCost = 0;
let currentDate = ""; // Default date (will be set by the user)
let currentTime = "09:00"; // Default time

// Function to allow dropping of items
function allowDrop(ev) {
    ev.preventDefault();
}

// Function to set data when an item is dragged
function drag(ev) {
    ev.dataTransfer.setData("name", ev.target.getAttribute("data-name"));
    ev.dataTransfer.setData("price", ev.target.getAttribute("data-price"));
}

// Function to handle the drop event
function drop(ev) {
    ev.preventDefault();
    const name = ev.dataTransfer.getData("name");
    const price = parseFloat(ev.dataTransfer.getData("price"));

    // Add item with date and time
    addToItinerary(name, price);
}

// Function to add an item to the itinerary with date and time
function addToItinerary(name, price) {
    // Get the selected date and time
    const date = currentDate ? currentDate : "No Date Selected";
    const time = currentTime;

    // Create list item for itinerary
    const li = document.createElement("li");
    li.innerHTML = `${name} - ${date} at ${time} - $${price.toFixed(2)} <button onclick="removeItem(this, ${price})">❌</button>`;
    document.getElementById("drop-zone").appendChild(li);

    // Update total cost
    totalCost += price;
    document.getElementById("total-cost").innerText = totalCost.toFixed(2);
}

// Function to remove an item from the itinerary
function removeItem(btn, price) {
    btn.parentElement.remove();
    totalCost -= price;
    document.getElementById("total-cost").innerText = totalCost.toFixed(2);
}

// Function to add a custom item with user input for name and price
function addCustomItem() {
    const nameInput = document.getElementById("custom-name");
    const priceInput = document.getElementById("custom-price");

    const name = nameInput.value.trim();
    const price = parseFloat(priceInput.value);

    if (!name || isNaN(price) || price < 0) {
        alert("Please enter a valid name and a positive price.");
        return;
    }

    // Add custom item with selected date and time
    addToItinerary(name, price);

    // Clear input fields
    nameInput.value = "";
    priceInput.value = "";
}

// Function to update the selected date
function updateDateSelection() {
    currentDate = document.getElementById("itinerary-date").value;
    console.log("Date selected:", currentDate);
}

// Function to update the selected time
function updateTimeSelection() {
    currentTime = document.getElementById("itinerary-time").value;
    console.log("Time selected:", currentTime);
}
