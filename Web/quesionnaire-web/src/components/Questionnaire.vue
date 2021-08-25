<template>
    <div>
        <div class="questionnaire-topbar">
            <div class="questionnaire-topbar-title">Questionnaire</div>
            <div class="questionnaire-topbar-progress">
                <KProgress :percent="progress" />
            </div>
        </div>
        <div class="questionnaire-body">
            <div class="questionnaire-question" v-for="(question, i) in questions" :key="question.id">
                <div class="questionnaire-question-title">Question {{i}}</div>
                <question :question="question" @add-answer="addAnswer" @remove-answer="removeAnswer"/>
            </div>
            <div>
                <button @click="onClickSubmit" :disabled="progress !== 100">Submit</button>
            </div>
        </div>
    </div>
</template>

<script lang="ts">
import Vue from 'vue'
import { QuestionsApi } from '../Infrastructure/API/QuestionsApi';
import { Question  as QuestionEntity} from '../Domain/Entities/Question';
import {SelectedAnswers} from '../Domain/SelectedAnswers/SelectedAnswers';
import KProgress from 'k-progress';

import Question from './Question.vue';

export default Vue.extend({
    name: 'Questionnaire',
    components: {
        Question,
        KProgress
    },
    data() {
        return {
            questions: [] as QuestionEntity[],
            selectedAnswers: [] as SelectedAnswers[]
        }
    },
    async beforeMount() {
        await QuestionsApi.getInstance().getQuestions()
        .then((res => {
            console.log(res);
            this.questions = res;
        }));
        this.initSelectedAnswers();
    },
    methods: {
        initSelectedAnswers() {
            console.log(this.questions.length);
            this.questions.map(question => {
                this.selectedAnswers.push(new SelectedAnswers(question.id));
            });
            console.log(this.selectedAnswers);
        },
        addAnswer(questionId: number, answerId: number) {
            let q = this.selectedAnswers.find(x => x.questionId == questionId);
            if(!q?.answers.includes(answerId)) {
                q?.answers.push(answerId);
            }
        },
        removeAnswer(questionId: number, answerId: number) {
            let q = this.selectedAnswers.find(x => x.questionId == questionId);
            q?.answers.splice(q.answers.indexOf(answerId), 1);
        },
        onClickSubmit() {
            QuestionsApi.getInstance().Calculate(this.selectedAnswers)
            .then(res => alert("Your score: " + res.score));
        }
    },
    computed: {
        progress() {
            let status = 0;
            this.selectedAnswers.map(element => {
                status += element.answers.length > 0 ? 1 : 0;
            });

            return status*10;
        }
    }
})
</script>

<style scoped>
.questionnaire-topbar {
    overflow: hidden; position: fixed; top: 0; width: 100%; background: white; z-index: 99; 
}
.questionnaire-topbar-title {
    font-size: 32px; font-weight: bold; color: #008CBA;
}
.questionnaire-topbar-progress {
    width: 80%; margin: 0 auto;
}
.questionnaire-body{
    text-align: left; width: 80%; margin: 0 auto; margin-top: 100px;
}
.questionnaire-question {
    padding-bottom: 25px;
}
.questionnaire-question-title {
    font-weight: bold; font-size: 22px; 
}
button {
    background-color: #008CBA;  border: none;   color: white;   padding: 15px 32px;
    text-align: center; text-decoration: none;  display: inline-block;  font-size: 16px;
    margin: 4px 2px;    cursor: pointer;
}
</style>