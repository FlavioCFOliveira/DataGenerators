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
                sh("dotnet restore Xumiga.DataGenerators.sln")
                sh("dotnet build Xumiga.DataGenerators.sln /p:Configuration=Release /p:Platform=\"Any CPU\" /p:ProductVersion=1.0.3.${env.BUILD_NUMBER}")
            }
        }
        stage('Test') {
            steps {
                echo 'Testing..'
                sh("dotnet restore Xumiga.DataGenerators.tests/Xumiga.DataGenerators.tests.csproj")
                sh("dotnet test Xumiga.DataGenerators.tests/Xumiga.DataGenerators.tests.csproj")
            }
        }
        stage('Deploy') {
            steps {
                echo 'Deploying....'
            }
        }
    }
}