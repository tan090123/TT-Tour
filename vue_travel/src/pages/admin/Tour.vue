<template lang="">
    <div class="tour-table">
        <div class="container-fluid">
            <h2 class="table-h2 text-center">Danh sách Tour</h2>
            <p class="text-end">
                <router-link class="create-table" :to="{ name: 'create-tour' }">
                    Create Tour <i class='bx bxs-file-plus icon'></i>
                </router-link>
            </p>
            <div class="table-container">
                <table class="table-container" style="width: 240rem;">
                    <thead>
                        <tr>
                            <th style="width: 12px;">ID</th>
                            <th style="width: 80px;">Code</th>
                            <th style="width: 180px;">Name</th>
                            <th>Image</th>
                            <th style="width: 30px;">Departure</th>
                            <th>Destination</th>
                            <th style="width: 200px;">Description</th>
                            <th style="width: 30px;">Price</th>
                            <th style="width: 30px;">PromotionPrice</th>
                            <th style="width: 30px;">DiscountTour</th>
                            <th>CheckinDays</th>
                            <th>CheckoutDays</th>
                            <th>TotalSit</th>
                            <th>AvailableSit</th>
                            <th>NumberDays</th>
                            <th>AvailablePeople</th>
                            <th>Type</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr v-for="item in displayedItems" :key="item.tourID">
                            <td>{{ item.tourID }}</td>
                            <td>{{ item.tourCode }}</td>
                            <td>{{ item.tourName }}</td>
                            <td><img style="width: 150px; height: 120px" :src="item.tourImage"
                                    :alt="item.destination"></td>
                            <td>{{ item.departure }}</td>
                            <td>{{ item.destination }}</td>
                            <td class="td-desc">{{ item.description }}</td>
                            <td>{{ formatter.format(item.price)
                                }}</td>
                            <td>{{ formatter.format(item.promotionPrice)
                                }}</td>
                            <td>{{ item.discountTour }}</td>
                            <td>{{ item.tourCheckinDays }}</td>
                            <td>{{ item.tourCheckoutDays }}</td>
                            <td>{{ item.tourTotalSit }}</td>
                            <td>{{ item.tourAvailableSit }}</td>
                            <td>{{ item.tour_NumberDays }}</td>
                            <td>{{ item.tour_AvalablePeople }}</td>
                            <td>{{ getTourTypeName(item.tourType) }}</td>
                            <td style="padding: 0 10px; width: 100px;">
                                <button class="btn btn-success" style="padding: 10px 15px; margin-right: 5px;"
                                    type="button" @click="editItem(item.tourID)" data-toggle="tooltip"
                                    data-placement="top" title="Edit">
                                    <i class="fa fa-edit"></i>
                                </button>
                                <button class="btn btn-danger" style="padding: 10px 15px;" type="button"
                                    @click="Confirm('Bạn có chắc chắn muốn xóa không ?') ? deleteItem(item.tourID) : '' "
                                    data-toggle="tooltip" data-placement="top" title="Delete">
                                    <i class="fa fa-trash"></i>
                                </button>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <Nagination :current-page="currentPage" :total-pages="totalPages" @page-change="changePage"/>
        </div>
    </div>
</template>
<script>
import Nagination from '@/components/ThePagination.vue';
import { mapState } from "vuex";
export default {
    name: 'tour-admin',
    components: {
        Nagination,
    },
    data() {
        return {
            perPage: 4,
            currentPage: 1,
            items: [],
            type: [],
            formatter: new Intl.NumberFormat("vi-VN", {
                style: "currency",
                currency: "VND",
            }),
        };
    },
    computed: {
        ...mapState(["tours","tourlist"]),
        totalPages() {
            return Math.ceil(this.tours.length / this.perPage);
        },
        displayedItems() {
            const start = (this.currentPage - 1) * this.perPage;
            const end = start + this.perPage;
            return this.tourlist.tours.slice(start, end);
        },
    },

    mounted() {
        this.getType();
        console.log(this.tourlist.tours);
    },
    methods: {
        changePage(page) {
            this.currentPage = page;
        },
        getType() {
            // eslint-disable-next-line
            axios.get('/api/TourType')
                .then((response) => {
                    // handle success
                    this.type = response.data;
                })
                .catch((error) => {
                    // handle error
                    console.log(error);
                });
        },

        // Set name tour type
        getTourTypeName(tourType) {
            const tourTypes = this.type.find(type => type.typeID === tourType);
            return tourTypes ? tourTypes.typeName : '';
        },

        Confirm(message) {
            return confirm(message);
        },

        deleteItem(itemId) {
            // eslint-disable-next-line
            axios.delete(`/api/Tour/${itemId}`)
                .then(response => {
                    // Xử lý kết quả thành công
                    console.log(response.data);

                    // Sau khi xóa thành công, cập nhật lại danh sách hiển thị
                    // this.items = this.items.filter(item => item.tourID !== itemId);
                    window.location.href = '/admin/tour';
                })
                .catch(error => {
                    // Xử lý lỗi
                    console.error(error);
                });
        },

        editItem(tourID) {
            // Lưu thông tin tour vào localStorage
            const tourData = this.displayedItems.find(item => item.tourID === tourID);
            localStorage.setItem('editTourData', JSON.stringify(tourData));

            // Chuyển sang trang chỉnh sửa
            this.$router.push({ path: '/admin/tour/edit', query: { id: tourID } });
        }

    }
}

</script>
<style lang="scss" scoped>
.tour-table {
    margin: 3rem;
}

.table-h2 {
    padding: 5rem 0 3rem 0;
    font-size: 3rem;
    font-weight: 600;
}

.create-table {
    color: #ff7675;
    align-items: end;
}

.table-container {
    width: 100%;
    overflow-x: scroll;
}

table {
    width: 100%;
    border-collapse: collapse;
}

th,
td {
    padding: 8px;
    text-align: left;
    border-bottom: 1px solid #ddd;
}

td {
    height: 1rem;
    min-height: 1rem;
    max-height: 1rem;
}

th {
    background-color: #ff7675;
    color: #fff;
    width: 100px;
}

/* .td-desc {
        display: -webkit-box;
        -webkit-box-orient: vertical;
        -webkit-line-clamp: 5;
        overflow: hidden;
        text-overflow: 'ellipsis';
    } */

.pagination {
    display: flex;
    justify-content: center;
    align-items: center;
    padding: 2rem 0;
}

.page-link {
    padding: 5px 10px;
    background-color: #fff;
    cursor: pointer;
}
</style>
