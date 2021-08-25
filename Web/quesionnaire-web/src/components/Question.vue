<template>
    <div class="question">
        <div class="question-question">{{this.question.questionText}}</div>
        <div v-for="answer in question.answers" :key="answer.id">
            <input type="checkbox" @click="onClick(answer.id, $event)" :checked="checked.includes(answer.id)" :id="answer.id" :key="checked[checked.length-1]">
            <label :for="answer.answerText">{{ answer.answerText }}</label>
        </div>
        <div v-if="question.choiceType == 1" class="question-comment">
            <label class="question-comment-label" for="fname">Comment: </label>
            <input class="question-comment-input" type="text" id="fname" name="fname">
        </div>
    </div>
</template> 

<script lang="ts">
import Vue from 'vue';
import {Question} from '../Domain/Entities/Question';

export default Vue.extend({
    name: 'Question',
    props: {
        question: {
            type: Object as () => Question,
            required: true
        }
    },
    data() {
        return {
            checked: [] as number[]
        }
    },
    methods: {
        onClick(index: number, e: any): void {
            e.preventDefault();
            switch(this.question.choiceType) {
                case 0:
                    this.onClickSingleAnswers(index);
                    break;
                case 1:
                    this.onClickMultipleAnswers(index);
                    break;
                default:
                    break;
            }
        },
        onClickMultipleAnswers(id: number) {
            if(!this.checked.includes(id)) {
                this.$emit("add-answer", this.question.id, id);
                this.checked.push(id);
            } else {
                this.$emit("remove-answer", this.question.id, id);
                this.checked.splice(this.checked.indexOf(id), 1);
            }            
        },
        onClickSingleAnswers(id: number) {
            this.$emit("remove-snaswer", this.question.id, this.checked[0]);
            this.checked = [];
            this.$emit("add-answer", this.question.id, id);
            this.checked.push(id);
        }
    }
})
</script>

<style scoped>
.question {
    padding-top: 8px;
}
.question-question {
    font-weight: bold;
}
.question-comment {
    padding-top: 5px;
}
.question-comment-label {
    font-weight: bold; 
}
.question-comment-input {
    width: 300px;   border: 0;  outline: 0; background: transparent;    border-bottom: 1px solid black;
}
</style>