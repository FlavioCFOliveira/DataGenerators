pipeline {
    agent any

    // define vars
    def version = "1.0.3.${env.BUILD_NUMBER}"

    stages {
        stage('Checkout') {
            steps {
                echo 'Checking out code..'
                checkout scm
            }
        }
        stage('Build') {
            steps {
                echo 'Building..'
                sh("dotnet restore Xumiga.DataGenerators.sln")
                sh("dotnet build Xumiga.DataGenerators.sln /p:Configuration=Release /p:Platform=\"Any CPU\" /p:ProductVersion=${version}")
            }
        }
        stage('Test') {
            steps {
                echo 'Testing..'
                sh("dotnet test Xumiga.DataGenerators.sln")
            }
        }
        stage('Deploy') {
            steps {
                echo 'Deploying....'
            }
        }
    }
}