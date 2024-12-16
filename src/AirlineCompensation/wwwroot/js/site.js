// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.
// Write your JavaScript code.
$(document).ready(function () {

    // Optional: Add action for the Send Offer button
    $('#sendOfferBtn').click(function () {
        alert('Offer Sent!');
    });

    $("#tblFlight tbody tr:first").addClass("highlight");

    reinitializeBindings();


    $("#tblFlight tbody").on("click", "tr", function () {
        // Remove 'highlight' class from all rows
        $("#tblFlight tbody tr").removeClass("highlight");
        // Add 'highlight' class to the clicked row
        $(this).addClass("highlight");

        // Get some data from the selected row (e.g., Flight ID or Number)
        var flightNumber = $(this).find("td:first").text().trim();

        $.ajax({
            url: "/Dashboard/GetFlightDetails",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify({ FlightNumber: "AB123", Departure: "New York" }), // Use properties matching your 'Flight' model
            success: function (response) {
                $("#passengerDetailsContainer").html(response); // Inject partial view into the container
                reinitializeBindings();
            },
            error: function (xhr, status, error) {
                console.error("Error:", error);
                alert("Failed to fetch passenger details.");
            }
        });
    });
});


// Function to reinitialize events and CSS
function reinitializeBindings() {
    
    $("#tblPassenger tbody tr").not('.hidden-content').on("click", function () {
        // Highlight the clicked row
        $(this).toggleClass("highlight");

        // Toggle the visibility of the next hidden div
        $(this).next(".hidden-content").find(".hidden-div").slideToggle();
        $(this).next(".hidden-content").toggleClass("highlight");

        var name = $(this).find("td:nth-child(2)").text().trim(); // Get the second cell's text

        // Display the data in an alert
        // alert("Name: " + name);
    });

    // Trigger when any row checkbox is changed
    $('.row-checkbox').change(function () {
        // Check if any checkbox is checked
        if ($('.row-checkbox:checked').length > 0) {
            $('#offerDiv').fadeIn(); // Show the floating div-
        } else {
            $('#offerDiv').fadeOut(); // Hide the floating div
        }
    });
}