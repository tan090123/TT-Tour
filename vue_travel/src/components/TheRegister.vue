<template lang="">
    <!-- ========== Start Register ========== -->
    <main class="login">
        <div class="container">
            <div class="row form-wrap">

                <div class="login-title text-center mb-4">
                    <h5>Chào mừng Quý khách đến với</h5>
                    <h2 class="fw-bold m-0">Vietravel</h2>
                </div>

                <div class="login-form bg-white">
                    <h2 class="text-center">Đăng ký</h2>
                    <form action="#" @submit.prevent="onSubmit">
                        <div class="mb-3">
                            <label for="name" class="form-label fw-bold">Họ và tên</label>
                            <span class="text-danger">*</span>
                            <input class="form-control" type="text" name="name" id="name" placeholder="Nhập họ và tên" v-model="fullname" @blur="error_Fullname" @input="error_Fullname">
                            <span class="text-danger">{{ errorFullname }}</span>
                        </div>
                        <div class="mb-3">
                            <label for="email" class="form-label fw-bold">Email</label>
                            <span class="text-danger">*</span>
                            <input class="form-control" type="text" name="email" id="email" placeholder="Nhập email" v-model="email" @blur="error_Email" @input="error_Email">
                            <span class="text-danger">{{ errorEmail }}</span>
                        </div>
                        <div class="mb-3">
                            <label for="phone_number" class="form-label fw-bold">Số điện thoại</label>
                            <span class="text-danger">*</span>
                            <input class="form-control" type="tel" name="phone_number" id="phone_number" placeholder="Nhập số điện thoại" v-model="phone_number" @blur="error_PhoneNumber" @input="error_PhoneNumber">
                            <span class="text-danger">{{ errorPhone_number }}</span>
                        </div>

                        <div class="mb-3">
                            <label for="password" class="form-label fw-bold">Mật khẩu</label>
                            <span class="text-danger">*</span>
                            <input class="form-control" type="password" name="password" id="password" placeholder="Nhập mật khẩu" v-model="password" @blur="error_Password" @input="error_Password">
                            <span class="text-danger">{{ errorPassword }}</span>
                        </div>
                        <div class="mb-3">
                            <label for="confirm_password" class="form-label fw-bold">Xác nhận mật khẩu</label>
                            <span class="text-danger">*</span>
                            <input class="form-control" type="password" name="confirm_password" id="confirm_password"
                                placeholder="Xác nhận mật khẩu" v-model="confirm_password" @blur="error_ConfirmPass" @input="error_ConfirmPass">
                                <span class="text-danger">{{ errorConfirm_password }}</span>
                        </div>

                        <button class="btn-primary w-100 fw-bold">
                            Đăng ký <i class="fas fa-sign-in-alt" aria-hidden="true"></i>
                        </button>
                        <div class="form-or">
                            <p>Hoặc</p>
                        </div>
                        <div class="form-on">
                            <div class="btn-facebook" id="btn_facebook">
                                <a href="!#">
                                    <i class="fab fa-facebook" aria-hidden="true"></i>
                                    <span>Tiếp tục với Facebook</span>
                                </a>
                            </div>

                            <div class="btn-google" id="btn_google">
                                <a href="!#">
                                    <i class="fab fa-google-plus-g"></i>
                                    <span>Tiếp tục với Google</span>
                                </a>
                            </div>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </main>
    <!-- ========== End Register ========== -->
</template>
<script>
export default {
    name: "register-component",
    data() {
        return {
            fullname: '',
            email: '',
            phone_number: '',
            password: '',
            confirm_password: '',
            errorFullname: '',
            errorEmail: '',
            errorPhone_number: '',
            errorPassword: '',
            errorConfirm_password: '',
            isValid: false
        }
    },
    mounted() {
        const userEmail = localStorage.getItem('userEmail');
        if (userEmail) {
            window.location.href = ('/');
        }
    },
    methods: {
        validateEmail(email) {
            const emailRegex = /^[a-zA-Z0-9.!#$%&’*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/;
            return emailRegex.test(email);
        },
        validatePhone(phone) {
            const phoneRegex = /^\d{10}$/;
            return phoneRegex.test(phone);
        },
        validatePass(password) {
            const passRegex = /^(?=[^a-z]*[a-z])(?=[^A-Z]*[A-Z])(?=\D*\d)[A-Za-z0-9!#%]{6,12}$/;
            return passRegex.test(password);
        },
        error_Fullname() {
            if (this.fullname.trim() === "") {
                this.errorFullname = "Họ và tên không được để trống";
                this.isValid = false;
            } else {
                this.errorFullname = '';
                this.isValid = true;
            }
        },
        error_Email() {
            if (this.email.trim() === "") {
                this.errorEmail = "Email không được để trống";
                this.isValid = false;
            } else if (!this.validateEmail(this.email)) {
                this.errorEmail = "Email không hợp lệ";
                this.isValid = false;
            } else {
                this.errorEmail = "";
                this.isValid = true;
            }
        },
        error_PhoneNumber() {
            if (this.phone_number.toString().trim() === "") {
                this.errorPhone_number = "Số điện thoại không được để trống";
                this.isValid = false;
            } else if (!this.validatePhone(this.phone_number)) {
                this.errorPhone_number = "Số điện thoại không hợp lệ";
                this.isValid = false;
            } else {
                this.errorPhone_number = '';
                this.isValid = true;
            }
        },
        error_Password() {
            if (this.password.trim() === "") {
                this.errorPassword = "Mật khẩu không được để trống";
                this.isValid = false;
            } else if (!this.validatePass(this.password)) {
                this.errorPassword = "Mật khẩu phải chứa ít nhất 6 ký tự, bao gồm chữ hoa, chữ thường và số";
                this.isValid = false;
            } else {
                this.errorPassword = '';
                this.isValid = true;
            }
        },
        error_ConfirmPass() {
            if (this.confirm_password.trim() === "") {
                this.errorConfirm_password = "Xác nhận mật khẩu không được để trống";
                this.isValid = false;
            } else if (this.password !== this.confirm_password) {
                this.errorConfirm_password = "Xác nhận mật khẩu không khớp";
                this.isValid = false;
            } else {
                this.errorConfirm_password = '';
                this.isValid = true;
            }
        },
        onSubmit() {
            if (this.isValid) {
                // eslint-disable-next-line no-undef
                axios.post('/api/RegisLogin/register', {
                    fullname: this.fullname,
                    phoneNumber: this.phone_number,
                    email: this.email,
                    password: this.password,
                    confirmPassword: this.confirm_password

                })
                    .then(response => {
                        // Xử lý kết quả
                        const result = response.data.result;
                        const errorMessage = response.data.errorMessage;
                        if (result) {
                            console.table(response.data);
                            // eslint-disable-next-line no-undef
                            Swal.fire({
                                title: 'Đăng ký thành công',
                                text: '💜',
                                icon: 'success',
                                confirmButtonText: 'OK'
                            }).then(() => {
                                // Chuyển hướng đến trang chủ
                                window.location.href = '/login';
                            });
                        } else {
                            // console.table(response.data);
                            // eslint-disable-next-line no-undef
                            Swal.fire({
                                title: 'Đăng nhập thất bại !!',
                                text: errorMessage,
                                icon: 'error',
                                confirmButtonText: 'OK',
                            }).then(() => {
                                window.location.href = '/register';
                            })
                        }
                    })
                    .catch(error => {
                        // Xử lý lỗi
                        console.error(error);
                        // eslint-disable-next-line no-undef
                        Swal.fire({
                            text: 'Đăng nhập thất bại !!',
                            icon: 'error',
                            confirmButtonText: 'OK',
                        });
                    });
            } else {
                // eslint-disable-next-line no-undef
                Swal.fire({
                    title: 'Vui lòng điền đúng thông tin -.-',
                    icon: 'warning',
                    confirmButtonText: 'OK'
                })
            }
        }
    }
}
</script>
<style lang="scss">
@import "@/assets/scss/_login.scss";
</style>