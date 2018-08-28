pipeline {
    agent any

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
                run 'dotnet restore Xumiga.DataGenerators.sln'
                run "dotnet build Xumiga.DataGenerators.sln /p:Configuration=Release /p:Platform=\"Any CPU\" /p:ProductVersion=1.0.3.${env.BUILD_NUMBER}"
            }
        }
        stage('Test') {
            steps {
                echo 'Testing..'
            }
        }
        stage('Deploy') {
            steps {
                echo 'Deploying....'
            }
        }
    }
}