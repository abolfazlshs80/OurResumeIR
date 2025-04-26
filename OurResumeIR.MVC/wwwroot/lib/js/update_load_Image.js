// وقتی روی تصویر کلیک می‌شود، فیلد انتخاب فایل فعال می‌شود
document.getElementById('imagePreview').addEventListener('click', function () {
    document.getElementById('fileInput').click();
});

// وقتی فایل انتخاب شد، تصویر پیش‌نمایش بروزرسانی می‌شود
document.getElementById('fileInput').addEventListener('change', function (event) {
    const file = event.target.files[0];
    if (file) {
        const reader = new FileReader();
        reader.onload = function (e) {
            document.getElementById('imagePreview').src = e.target.result;
        };
        reader.readAsDataURL(file);
    }
});

document.getElementById('fileInput').addEventListener('change', function (event) {
    const file = event.target.files[0];
    if (file) {
        const formData = new FormData();
        formData.append('file', file);

        // ارسال تصویر به سرور با AJAX
        fetch('/User/User/UploadImageProfile', {
                method: 'POST',
                body: formData
            })
            .then(response => response.json())
            .then(data => {
                console.log('Success:', data);
                alert('Image uploaded successfully!');
            })
            .catch(error => {
                console.error('Error:', error);
                alert('Failed to upload image.');
            });
    }
});