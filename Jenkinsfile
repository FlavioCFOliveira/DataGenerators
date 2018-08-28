pipeline {
    agent any

    stages {
        stage('Checkout') {
            steps {
                echo 'Checking out code..'
                checkout smc
            }
        }
        stage('Build') {
            steps {
                echo 'Building..'
                bat 'nuget restore SolutionName.sln'
                bat "\"${tool 'MSBuild'}\" SolutionName.sln /p:Configuration=Release /p:Platform=\"Any CPU\" /p:ProductVersion=1.0.0.${env.BUILD_NUMBER}"
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