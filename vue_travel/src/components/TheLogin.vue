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
                    <form action="#" @submit.prevent="submitForm">
                        <div class="mb-3">
                            <label for="email" class="form-label fw-bold">Số điện thoại hoặc email:</label>
                            <span class="text-danger">*</span>
                            <input class="form-control" v-model="taikhoan" type="text" name="email" id="email" placeholder="Nhập email hoặc số điện thoại"  @input="error_Taikhoan"  @blur="error_Taikhoan" >
                           <span v-if="errors.taikhoan" class="text-danger">{{ errors.taikhoan }}</span>
                        </div>

                        <div class="mb-3">
                            <label for="email" class="form-label fw-bold">Mật khẩu</label>
                            <span class="text-danger">*</span>
                            <input class="form-control" type="password" name="password" id="password" placeholder="Nhập mật khẩu" v-model="password"  @blur="error_Password"  @input="error_Password"  >
                            <span v-if="errors.password" class="text-danger">{{ errors.password }}</span>

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
            taikhoan: '',
            password: '',
            types: [],
            status: false,
            errors: {
                taikhoan: '',
                password: '',
            },
        }
    },
    methods: {
        // validatePass(password) {
        //     const passRegex = /^(?=[^a-z]*[a-z])(?=[^A-Z]*[A-Z])(?=\D*\d)[A-Za-z0-9!#%]{6,12}$/;
        //     return passRegex.test(password);
        // },
        error_Taikhoan() {
            if (this.taikhoan.trim() === "") {
                this.errors.taikhoan = "Tài khoản không được để trống";
                this.status = false;
                this.status = false;
            } else {
                this.errors.taikhoan = "";
                this.status = true;
            }
        },
        error_Password() {
            if (this.password.trim() === "") {
                this.errors.password = "Mật khẩu không để trống";
                this.status = false;
            } else {
                this.errors.password = '';
                this.status = true;
            }
        },
        submitForm() {
            this.onLogin();
        },
        onLogin() {
            if (this.status) {
                console.log(this.status);
                // eslint-disable-next-line no-undef
                axios.post('/api/RegisLogin/login', {
                    value: this.taikhoan,
                    password: this.password
                })
                    .then(response => {
                        // Xử lý kết quả
                        const result = response.data.result;
                        if (result) {
                            console.table(response.data);
                            // eslint-disable-next-line no-undef
                            Swal.fire({
                                title: 'Đăng nhập thành công',
                                text: '💜',
                                icon: 'success',
                                confirmButtonText: 'OK'
                            }).then(() => {
                                // Lưu email vào localStorage hoặc sessionStorage
                                localStorage.setItem('userEmail', this.taikhoan);

                                // Chuyển hướng đến trang chủ
                                window.location.href = '/';
                            });
                        } else {
                            const errorMessage = response.data.errorMessage;
                            console.table(response.data);
                            // eslint-disable-next-line no-undef
                            Swal.fire({
                                title: 'Đăng nhập thất bại !!',
                                text: errorMessage,
                                icon: 'error',
                                confirmButtonText: 'OK',
                            });
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
            }
        },
    },
}
</script>
<style lang="scss">
@import "@/assets/scss/_login.scss";
</style>