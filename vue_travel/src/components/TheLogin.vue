<template lang="">
    <!-- ========== Start Main Login ========== -->
    <main class="login">
        <div class="container">
            <div class="row form-wrap">

                <div class="login-title text-center mb-4">
                    <h5>Chào mừng Quý khách đến với</h5>
                    <h2 class="fw-bold m-0">Vietravel</h2>
                </div>

                <div class="login-form bg-white">
                    <h2 class="text-center">Đăng nhập</h2>
                    <form action="#">
                        <div class="mb-3">
                            <label for="email" class="form-label fw-bold">Số điện thoại hoặc email</label>
                            <span class="text-danger">*</span>
                            <input class="fomr-control" v-model="inputValue" @blur="validateInput" type="text" name="email" id="email" placeholder="Tài khoản">
                            <p v-if="isError" class="error-message">{{ errorMessage }}</p>
                        </div>

                        <div class="mb-3">
                            <label for="email" class="form-label fw-bold">Mật khẩu</label>
                            <span class="text-danger">*</span>
                            <input class="fomr-control" type="text" name="email" id="email" placeholder="Mật khẩu">
                            <div class="text-end">
                                <router-link :to="{name: 'register_component'}" target="_blank" rel="nofollow no-referrer">Đăng ký</router-link>
                                <span>hoặc</span>
                                <a href="!#" target="_blank" rel="nofollow no-referrer">Lấy lại mật khẩu</a>
                            </div>
                        </div>

                        <button class="btn-primary w-100 fw-bold">
                            Đăng nhập <i class="fas fa-sign-in-alt" aria-hidden="true"></i>
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
    <!-- ========== End Main Login ========== -->
</template>
<script>
export default {
    name: "login_component",
    data() {
        return {

            inputValue: "",
            isError: false,
            errorMessage: "",
        }
    },
    methods: {
        validateInput() {
            // Kiểm tra nếu giá trị rỗng
            if (this.inputValue === "") {
                this.isError = true;
                this.errorMessage = "Vui lòng nhập giá trị.";
            }
            // Kiểm tra định dạng số điện thoại
            else if (this.isPhoneNumber(this.inputValue)) {
                this.isError = false;
                this.errorMessage = "";
            }
            // Kiểm tra định dạng email
            else if (this.isEmail(this.inputValue)) {
                this.isError = false;
                this.errorMessage = "";
            }
            // Nếu không phù hợp với cả số điện thoại và email
            else {
                this.isError = true;
                this.errorMessage = "Vui lòng nhập số điện thoại hoặc email hợp lệ.";
            }
        },
        isPhoneNumber(value) {
            // Sử dụng biểu thức chính quy để kiểm tra định dạng số điện thoại
            // Ví dụ: kiểm tra xem giá trị có 10 chữ số và bắt đầu bằng số 0 hay không
            const phoneNumberRegex = /^0\d{9}$/;
            return phoneNumberRegex.test(value);
        },
        isEmail(value) {
            // Sử dụng biểu thức chính quy để kiểm tra định dạng email
            const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
            return emailRegex.test(value);
        },
    },
}
</script>
<style lang="scss">
@import "@/assets/scss/_login.scss";

.error-message {
    color: red;
}
</style>