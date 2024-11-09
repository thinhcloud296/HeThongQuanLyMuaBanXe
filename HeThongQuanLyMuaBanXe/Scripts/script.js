// script.js
let slideIndex = 0;
const slides = [
    "/Images/August-Motorcars-Supercar-Showroom.jpg",
    "/Images/2Screenshot 2024-11-08 103402.jpg",
    "/Images/1Screenshot 2024-11-08 102958.jpg"
];

// Hiển thị slide theo chỉ số
function showSlide(index) {
    const pic = document.getElementById("pic");
    pic.src = slides[index];

    const buttons = document.querySelectorAll("#list ul li button");
    buttons.forEach((button, idx) => {
        button.classList.toggle("active", idx === index);
    });
}

// Thay đổi chỉ số slide
function changeSlide(step) {
    slideIndex = (slideIndex + step + slides.length) % slides.length;
    showSlide(slideIndex);
}

// Chuyển đến slide theo chỉ số cụ thể
function indexNumber(index) {
    slideIndex = index;
    showSlide(slideIndex);
}

// Tự động chuyển ảnh mỗi 3 giây
setInterval(() => {
    changeSlide(1); // Chuyển sang slide tiếp theo
}, 2000);

// Hiển thị slide đầu tiên khi tải trang
document.addEventListener("DOMContentLoaded", () => showSlide(slideIndex));


