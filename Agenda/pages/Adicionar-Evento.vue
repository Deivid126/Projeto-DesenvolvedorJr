<template>
    <v-card>
    <v-form ref="Adicionar Compromisso" v-model="valid" lazy-validation>
        <v-text-field v-model="evento.name" :counter="50" :rules="nameRules" label="Descreva o Compromisso" required>
        </v-text-field>

        <v-text-field v-model="evento.Data" :rules="DataRules" label="Data(Ex:12/05/2022)" required></v-text-field>

        <v-text-field v-model="evento.Hora" :rules="HoraRules" label="Horário(Ex:12:00h)" required></v-text-field>

        <v-select v-model="evento.select" :items="items" :rules="[v => !!v || 'Compromisso é necessário']"
            label="Compromisso" required></v-select>


        <v-btn :disabled="!valid" color="success" class="mr-4" @click="submit">
            Salvar
        </v-btn>

        <v-btn color="error" class="mr-4" @click="reset">
            Limpar
        </v-btn>
        <pre>
        {{ evento }}
    </pre>
    </v-form>
    <v-data-table
    :headers="headers"
    :items="Eventos"
    :items-per-page="5"
    class="elevation-1"
  ></v-data-table>
</v-card>
</template>

<script>
export default {
    data: () => ({
        valid: true,
        evento: {
            name: '',
            Data: '',
            Hora: '',
            select: ''

        },
        name: '',
        nameRules: [
            v => !!v || 'Descrição é necessária',
            v => (v && v.length <= 50) || 'Descrição muito grande',
        ],
        Data: '',
        DataRules: [
            v => !!v || 'Data é necessária',
        ],
        Hora: '',
        HoraRules: [
            v => !!v || 'Hora é necessária'
        ],
        headers: [
          {
            text: 'Compromisso',
            align: 'start',
            sortable: false,
            value: 'name',
          },
          { text: 'Hora', value: 'Hora' },
          { text: 'Data', value: 'Data' },
          { text: 'Local', value: 'select' }
          
        ],
        evento:[],
        select: null,
        items: [
            'Faculdade',
            'Relacionamento',
            'Trabalho',
            'Igreja',
        ],
        checkbox: false,
    }),

    methods: {
        async submit() {
            debugger

    try{
            var response = await this.$axios({
                method: "POST",
                url: "https://localhost:7140/Evento",
                data: this.evento
            });

            debugger;

            var responseGet = await this.$axios({
                method: "GET",
                url: "https://localhost:7140/Evento"
            });
            debugger;
            this.evento = responseGet.data;
        }
        catch{}
        },
        reset() {
            this.$refs.form.reset()
        }
    },
}
</script>

<style>
</style>
