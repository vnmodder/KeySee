<template>
    <div>
        <div class="d-flex justify-content-start">
            <div class="d-flex align-items-center col-md-2">
                <span v-if="hasChild" @click="iconClick" style="width: 1rem;">
                    <i v-if="showChild" class="fas fa-caret-down cursor-pointer"></i>
                    <i v-else class="fas fa-caret-right cursor-pointer"></i>
                </span>
                <span :style="hasChild ? '' : 'margin-left: 1.05rem !important'">
                    <!-- {{ node?.name }} -->
                    <a :href="node?.path">
                    {{ node?.name }}
                </a>
                </span>
            </div>
            <!-- <span class="col-md-2" :style="'margin-left: ' + (-1.2 * depth) + 'rem !important'">
                <a :href="node?.path">
                    {{ node?.path }}
                </a>
            </span>
            <span v-if="node?.description" class="col-md-4" :style="'margin-left: ' + (0.2 * depth) + 'rem !important'">
                {{ node?.description }}
            </span> -->
        </div>
        <TreeView class="ms-4" v-if="showChild" v-for="child in node?.children" :key="child?.name" :node="child"
            :depth="depth + 1" />
    </div>
</template>

<script setup lang="ts">
import { ref, computed } from 'vue';

interface Node {
    id?: number;
    name?: string;
    path?: string;
    pid?: number;
    description?: string
    children?: Array<Node>;
}

interface Props {
    node?: Node;
    depth: number;
}
const props = defineProps<Props>();

const showChild = ref(true);

const hasChild = computed(() => props.node?.children && props.node?.children.length > 0);

const iconClick = () => {
    showChild.value = !showChild.value;
};
</script>

<style scoped>
.cursor-pointer {
    cursor: pointer;
}
</style>
