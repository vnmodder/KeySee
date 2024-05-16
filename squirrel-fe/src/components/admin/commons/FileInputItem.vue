<template>
    <div class="mb-3" :class="colControl ? 'col-md-' + colControl : ''">
        <div class="input-group admin-file-control" @click="choseFile">
            <input class="form-control btn-outline-custom" :value="model?.name" type="text" readonly :id="id"
                :placeholder="attribute && attribute?.placeholder" />
            <button class="btn btn-outline-custom-2 admin-custom-radius">
                <i class="fas fa-paperclip  "></i>
            </button>
            <input type="file" ref="fileInput" style="display: none" @change="handleFileUpload" />
        </div>
    </div>
</template>

<script setup lang="ts">
import { defineProps, ref } from 'vue'
import type { BaseAttribute } from './interface';

const fileInput = ref<any>();

interface Attribute {
    placeholder?: string
}

const choseFile = () => {
    fileInput?.value.click();
}

const handleFileUpload = () => {
    model.value = fileInput?.value?.files[0]
}

interface Props extends BaseAttribute {
    attribute?: Attribute,
}

const model = defineModel<File>()

withDefaults(defineProps<Props>(), {
    id: '',
    labelValue: '',
    colControl: 4,
    attribute: undefined
})

</script>

<style scoped>
.admin-file-input {
    width: 100%;
}
</style>
