<template lang="">
    <div class="create-tour">
        <h2>Tạo danh sách Tour</h2>
        <form>
            <div class="form-group">
                <label for="code">Code:</label>
                <input type="text" id="code" name="code">
            </div>
            <div class="form-group">
                <label for="name">Name:</label>
                <input type="text" id="name" name="name">
            </div>
            <div class="form-group">
                <label for="upload">Upload Image:</label>
                <input type="file" id="upload" name="upload">
            </div>
            <div class="form-group">
                <label for="departure">Departure:</label>
                <input type="text" id="departure" name="departure">
            </div>
            <div class="form-group">
                <label for="destination">Destination:</label>
                <input type="text" id="destination" name="destination">
            </div>
            <div class="form-group">
                <label for="description">Description:</label>
                <textarea id="description" name="description"></textarea>
            </div>
            <div class="form-group">
                <label for="price">Price:</label>
                <input type="number" id="price" name="price">
            </div>
            <div class="form-group">
                <label for="promotionPrice">Promotion Price:</label>
                <input type="number" id="promotionPrice" name="promotionPrice">
            </div>
            <div class="form-group">
                <label for="discountTour">Discount Tour:</label>
                <input type="number" id="discountTour" name="discountTour">
            </div>
            <div class="form-group">
                <label for="checkinDays">Checkin Days:</label>
                <input type="text" id="checkinDays" name="checkinDays">
            </div>
            <div class="form-group">
                <label for="checkoutDays">Checkout Days:</label>
                <input type="text" id="checkoutDays" name="checkoutDays">
            </div>
            <div class="form-group">
                <label for="totalSit">Total Sit:</label>
                <input type="number" id="totalSit" name="totalSit">
            </div>
            <div class="form-group">
                <label for="availableSit">Available Sit:</label>
                <input type="number" id="availableSit" name="availableSit">
            </div>
            <div class="form-group">
                <label for="type">Type:</label>
                <select id="type" name="type">
                    <option value="1">Type 1</option>
                    <option value="2">Type 2</option>
                    <option value="3">Type 3</option>
                </select>
            </div>
            <button type="submit">Submit</button>
        </form>

    </div>
</template>
<script>
export default {

}
</script>
<style lang="">

</style>
