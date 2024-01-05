// Get the context of the canvas element
var ctx = document.getElementById('myChart').getContext('2d');

// Sample data
var data = {
    labels: ['January', 'February', 'March', 'April', 'May', 'June',
        'July', 'August', 'September', 'October', 'November', 'Decemeber'],
    datasets: [{
        label: 'Monthly Rent Revenue',
        data: [25379, 19564, 30456, 25410, 25980, 17965,
            25985, 28450, 34561, 24958, 30564, 30980],
        backgroundColor: 'rgba(75, 192, 192, 0.2)',
        borderColor: 'rgba(75, 192, 192, 1)',
        borderWidth: 1
    }]
};

// Chart configuration
var options = {
    scales: {
        y: {
            beginAtZero: true
        }
    }
};

// Create the chart
var myChart = new Chart(ctx, {
    type: 'bar',
    data: data,
    options: options
});