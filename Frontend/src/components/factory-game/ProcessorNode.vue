<script setup lang="ts">
import type { ProcessorNodeData } from '@/models/factory-game/ProcessorNodeData'
import BaseNode from './BaseNode.vue'

defineProps<{
  data: ProcessorNodeData
}>()
</script>

<template>
  <BaseNode :name="data.name">
    <template #icon>
      <i class="pi pi-cog"></i>
    </template>
  </BaseNode>
</template>
